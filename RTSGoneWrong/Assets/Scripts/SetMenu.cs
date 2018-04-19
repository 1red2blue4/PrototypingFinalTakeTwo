using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenu : MonoBehaviour {

	public static bool menuOn;
	public static bool gameHasStarted;

	public void SetMenuOn(bool isOn)
	{
		menuOn = isOn;
		print(menuOn);
	}
}
