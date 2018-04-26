using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(int myLevelNum)
	{
		SetMenu.levelNum = myLevelNum;
		SceneManager.LoadScene(SetMenu.levelNames[SetMenu.levelNum]);
	}

	public void LoadTech(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
}
