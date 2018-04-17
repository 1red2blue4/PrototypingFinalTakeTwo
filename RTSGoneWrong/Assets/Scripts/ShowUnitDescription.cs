using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUnitDescription : MonoBehaviour {

	private GameObject unitName;
	private GameObject unitStats;
	public string name;
	public string stats;
	public UnitScript unitType;

	// Use this for initialization
	void Start() 
	{
		unitName = GameObject.FindGameObjectWithTag("UnitName");
		unitStats = GameObject.FindGameObjectWithTag("UnitStats");

		name = "" + unitType.thisUnitType + "";
		stats = "Health: " + unitType.unitHealth + "        " + "Attack: " + unitType.unitAttack + "        " + "Speed: " + unitType.unitSpeed + "        " + "Range: " + unitType.unitRange + "        " + "Cost: " + unitType.unitCost;
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	public void OnMouseOver()
	{
		unitName.GetComponent<Text>().text = name;
		unitStats.GetComponent<Text>().text = stats;
	}
}
