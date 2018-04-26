using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


	//1 through 8 is for units, 9 is for the weather machine
	public static int currentSelectedUnit;
	//add the highlight perimeter into this gameobject spot in order to track its location
	public GameObject highlightPerimeter;
	//all the buttons on the screen
	public GameObject[] buttons;
	//the scene's main camera, please drag into script
	[SerializeField] private Camera mainCamera;
	[SerializeField] private float cameraSpeed;
	[SerializeField] private float cameraZoomSpeed;

	[SerializeField] private GameObject tank;
	[SerializeField] private GameObject healer;
	[SerializeField] private GameObject flagBearer;
	[SerializeField] private GameObject sniper;
	[SerializeField] private GameObject barbarian;

	private bool buttonBeingPressed;

    // Variables for keeping track of unit spawn points
    private bool isPlayerDead;
    public bool updateList;
    private List<GameObject> spawningObjects;
    public int selectedBaseIndex = 0;
    private GameObject selectedBase;
    private GameObject selector;

    // Use this for initialization
    void Start()
    {
        isPlayerDead = false;
        cameraSpeed = 10.0f;
		cameraZoomSpeed = 5.0f;

        currentSelectedUnit = 1;
		buttonBeingPressed = false;
        spawningObjects = new List<GameObject>();
        UpdateSpawnList();
        updateList = false;
        selector = GameObject.Find("BaseSelector");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead /*&& !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GamePause>().isEnemyDead*/)
        {

            if (selectedBase == null)
            {
                UpdateSpawnList();
                if (spawningObjects.Count > 0)
                {
                    selectedBaseIndex = 0;
                    selectedBase = spawningObjects[selectedBaseIndex];
                    selector.transform.localScale = new Vector3(1.4f, 0.7f, 1.0f);
                    selector.transform.position = spawningObjects[selectedBaseIndex].transform.position;
                    selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y - 1.5f, selector.transform.position.z);
                }
            }
            if (updateList)
            {
                updateList = false;
                UpdateSpawnList();
            }
            if (spawningObjects[selectedBaseIndex].GetComponent<UnitGeneralBehavior>() != null)
            {
                selector.transform.position = spawningObjects[selectedBaseIndex].transform.position;
            }
            if (Input.GetMouseButtonDown(0))
            {
                ClickSelectUnit();
            }
            MoveCamera();

            if (!SetMenu.menuOn)
            {
                gameObject.GetComponent<Canvas>().enabled = false;
            }

			/*
            if (Input.GetKeyDown(KeyCode.Z))
            {
                selectedBaseIndex++;
                if (selectedBaseIndex >= spawningObjects.Count)
                {
                    selectedBaseIndex = 0;
                }
                //selector.transform.position = new Vector3(selector.transform.position.x, GameObject.Find("AlliedBases").transform.GetChild(selectedBaseIndex).position.y - 1.5f, selector.transform.position.z);
                selectedBase = spawningObjects[selectedBaseIndex];
                selector.transform.position = spawningObjects[selectedBaseIndex].transform.position;
                if (spawningObjects[selectedBaseIndex].GetComponent<UnitGeneralBehavior>() != null)
                {
                    selector.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
                }
                else
                {
                    selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y - 1.5f, selector.transform.position.z);
                    selector.transform.localScale = new Vector3(1.4f, 0.7f, 1.0f);
                }
            }
            */

            if (!buttonBeingPressed)
            {
                if (Input.GetAxis("Unit1") > 0)
                {
                    PressButton(1);
                    buttonBeingPressed = true;
                }
                if (Input.GetAxis("Unit2") > 0)
                {
                    PressButton(2);
                    buttonBeingPressed = true;
                }
                if (Input.GetAxis("Unit3") > 0)
                {
                    PressButton(3);
                    buttonBeingPressed = true;
                }
                if (Input.GetAxis("Unit4") > 0)
                {
                    PressButton(4);
                    buttonBeingPressed = true;
                }
                if (Input.GetAxis("Unit5") > 0)
                {
                    PressButton(5);
                    buttonBeingPressed = true;
                }
            }
            if (Input.GetAxis("Unit1") <= 0 && Input.GetAxis("Unit2") <= 0 && Input.GetAxis("Unit3") <= 0 && Input.GetAxis("Unit4") <= 0 && Input.GetAxis("Unit5") <= 0)
            {
                buttonBeingPressed = false;
            }

        }

    }

    void ClickSelectUnit()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            GameObject unit = hit.transform.gameObject;
            for (int i = 0; i < spawningObjects.Count; i++)
            {
                if (spawningObjects[i] == unit)
                {
                    selectedBaseIndex = i;
                    selectedBase = spawningObjects[selectedBaseIndex];
                    GameObject selector = GameObject.Find("BaseSelector");
                    selector.transform.position = spawningObjects[selectedBaseIndex].transform.position;
                    if (spawningObjects[selectedBaseIndex].GetComponent<UnitGeneralBehavior>() != null)
                    {
                        selector.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
                    }
                    else
                    {
                        selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y - 1.5f, selector.transform.position.z);
                        selector.transform.localScale = new Vector3(1.4f, 0.7f, 1.0f);
                    }
                    return;
                }
            }
        }
    }


    private void UpdateSpawnList()
    {
        spawningObjects.Clear();
        GameObject[] bases = GameObject.FindGameObjectsWithTag("PlayerBase");
        for (int i = 0; i < bases.GetLength(0); i++)
        {
            spawningObjects.Add(bases[i]);
        }

        if (spawningObjects.Count == 0)
        {
            YouLose();
        }
        GameObject[] allUnits = GameObject.FindGameObjectsWithTag("Unit");
        for (int i = 0; i < allUnits.GetLength(0); i++)
        {
            if ((allUnits[i].GetComponent<UnitScript>().thisUnitType == UnitScript.unitTypes.Flagbearer) &&
                (allUnits[i].GetComponent<UnitGeneralBehavior>().goesRight == true))
            {
                spawningObjects.Add(allUnits[i]);
            }
        }
    }
 
    public void PressButton(int buttonNum)
	{
		currentSelectedUnit = buttonNum;

		GameObject createType = null;
		if (currentSelectedUnit == 1)
		{
			createType = sniper;
		}
        else if (currentSelectedUnit == 2)
        {
			createType = barbarian;
        }
		else if (currentSelectedUnit == 3)
		{
			createType = tank;
		}
		else if (currentSelectedUnit == 4)
		{
			createType = healer;
		}
		else if (currentSelectedUnit == 5)
		{
			//UpdateList to keep track
			updateList = true;
			createType = flagBearer;
		}
		if (createType != null && ResourceDisplay.favour >= createType.GetComponent<UnitScript>().unitCost)
		{
           createType.GetComponent<UnitGeneralBehavior>().goesRight = true;
           //selectedBase = GameObject.Find("AlliedBases").transform.GetChild(selectedBaseIndex).gameObject;
           Instantiate(createType, selectedBase.transform.position, Quaternion.identity);

			ResourceDisplay.favour -= createType.GetComponent<UnitScript>().unitCost;
		}

		highlightPerimeter.GetComponent<RectTransform>().position = buttons[currentSelectedUnit - 1].GetComponent<RectTransform>().position;
		highlightPerimeter.GetComponent<RectTransform>().position += new Vector3(0.0f, 0.0f, -1.0f);
        
		GameObject myEventSystem = GameObject.Find("EventSystem");
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

	private void MoveCamera()
	{
		if (Input.GetAxis("Vertical") > 0) 
		{
			mainCamera.transform.position += new Vector3(0.0f, cameraSpeed * Time.deltaTime, 0.0f);
		}
		else if (Input.GetAxis("Vertical") < 0) 
		{
			mainCamera.transform.position += new Vector3(0.0f, -cameraSpeed * Time.deltaTime, 0.0f);
		}

		if (Input.GetAxis("Horizontal") > 0) 
		{
			mainCamera.transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
		}
		else if (Input.GetAxis("Horizontal") < 0) 
		{
			mainCamera.transform.position += new Vector3(-cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
		}

		if (Input.GetAxis("Zoom") > 0)
		{
			mainCamera.orthographicSize -= cameraZoomSpeed * Time.deltaTime;
		}
		else if (Input.GetAxis("Zoom") < 0)
		{
			mainCamera.orthographicSize += cameraZoomSpeed * Time.deltaTime;
		}
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.orthographicSize -= cameraZoomSpeed * Time.deltaTime * 5;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.orthographicSize += cameraZoomSpeed * Time.deltaTime * 5;
        }
    }

    void YouLose()
    {
        isPlayerDead = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<GamePause>().isPlayerDead = true;
    }
}