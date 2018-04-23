using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource[] allSounds;

	// Use this for initialization
	void Start() 
	{
		allSounds = GameObject.FindObjectsOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		for (int i = 0; i < allSounds.GetLength(0); i++)
		{
			allSounds[i].volume = SetMenu.masterVolume;
		}
	}
}
