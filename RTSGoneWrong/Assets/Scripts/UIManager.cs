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

	[SerializeField] private GameObject tank;
	[SerializeField] private GameObject healer;
	[SerializeField] private GameObject flagBearer;
	[SerializeField] private GameObject sniper;
	[SerializeField] private GameObject barbarian;
    // Selecting Base
    public int selectedBaseIndex = 1;
    private GameObject selectedBase;

	private bool buttonBeingPressed;


    // Number of Bases
    public int numBases = 3;



    // Use this for initialization
    void Start()
    {
        currentSelectedUnit = 1;
		buttonBeingPressed = false;
		//SetMenu.menuOn = true;
		print(SetMenu.menuOn);
    }

    // Update is called once per frame
    void Update()
    {

        MoveCamera();

		if (!SetMenu.menuOn)
		{
			gameObject.GetComponent<Canvas>().enabled = false;
		}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            selectedBaseIndex++;
            GameObject selector = GameObject.Find("BaseSelector");
            if (selectedBaseIndex > numBases)
            {
                selectedBaseIndex = 1;
            }
            selector.transform.position = new Vector3(selector.transform.position.x, GameObject.Find("AlliedBases").transform.GetChild(selectedBaseIndex).position.y - 1.5f, selector.transform.position.z);
        }

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

    public void PressButton(int buttonNum)
	{
		print(buttonNum);
		currentSelectedUnit = buttonNum;

		GameObject createType = null;
		if (currentSelectedUnit == 1)
		{
			createType = tank;
		}
        else if (currentSelectedUnit == 2)
        {
			createType = healer;
        }
		else if (currentSelectedUnit == 3)
		{
			createType = flagBearer;
		}
		else if (currentSelectedUnit == 4)
		{
			createType = sniper;
		}
		else if (currentSelectedUnit == 5)
		{
			createType = barbarian;
		}
		if (createType != null && ResourceDisplay.favour >= createType.GetComponent<UnitScript>().unitCost)
		{
           createType.GetComponent<UnitGeneralBehavior>().goesRight = true;
           selectedBase = GameObject.Find("AlliedBases").transform.GetChild(selectedBaseIndex).gameObject;
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
	}
}
