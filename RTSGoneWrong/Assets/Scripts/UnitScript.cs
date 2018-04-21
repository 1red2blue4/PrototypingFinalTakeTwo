using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

	public enum unitTypes
    {
        Tank,
        Healer,
        Freshman,
        Sniper,
        Flagbearer,
        HomeBase
    }

    [SerializeField] public unitTypes thisUnitType;
	[SerializeField] public int unitHealth;
	[SerializeField] public int unitAttack;
	[SerializeField] public float unitSpeed;
	[SerializeField] public int unitCost;
	[SerializeField] public float unitRange;
    public bool isDamaged;

    public int unitMaxHealth;

    private Vector3 mouseRightClickPositionLatest;


    // Use this for initialization
    void Start() 
	{
        unitMaxHealth = unitHealth;
        mouseRightClickPositionLatest = transform.position;
		SetHealthBar();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
            mouseRightClickPositionLatest = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        if (unitHealth <=0 )
        {
            if (((thisUnitType == unitTypes.Flagbearer) &&  //If flagbearer
                (gameObject.GetComponent<UnitGeneralBehavior>().goesRight == true)) ||
                ((thisUnitType == unitTypes.HomeBase) && // If base
                (gameObject.tag == "PlayerBase")))
            {
                GameObject.Find("FullMenu").transform.GetChild(0).GetComponent<UIManager>().updateList = true;
            }
            else if (((thisUnitType == unitTypes.Flagbearer) &&  //If flagbearer
                (gameObject.GetComponent<UnitGeneralBehavior>().goesRight == false)) ||
                ((thisUnitType == unitTypes.HomeBase) && // If base
                (gameObject.tag == "EnemyBase")))
            {
                GameObject.Find("EnemyBases").GetComponent<EnemySpawner>().updateList = true;
            }
            Destroy(gameObject);
        }

        isDamaged = (unitHealth < unitMaxHealth);

		SetHealthBar();
    }

    public Vector3 NormalBehavior()
    {
        return mouseRightClickPositionLatest;
    }

	public void SetHealthBar()
	{
        if (gameObject.tag == "Unit")
        {
            GameObject myHealthBar = transform.GetChild(0).GetChild(0).gameObject;
            ScaleBackHealthBar myAffectHealthScript = myHealthBar.GetComponent<ScaleBackHealthBar>();
            myAffectHealthScript.percentHealth = (float)unitHealth / (float)unitMaxHealth;
        }
	}
}