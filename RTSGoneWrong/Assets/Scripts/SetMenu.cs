using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenu : MonoBehaviour {

	public static bool menuOn;
	public static bool gameHasStarted;
	public static float masterVolume;

	public void SetMenuOn(bool isOn)
	{
		menuOn = isOn;
	}

	public void SetMasterVolume(float vol)
	{
		masterVolume = vol;
		print(masterVolume);
	}
}
