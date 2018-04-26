using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	public void LoadLevel(int myLevelNum)
    {
		SetMenu.levelNum = myLevelNum;
		SceneManager.LoadScene(SetMenu.levelNames[SetMenu.levelNum]);
    }

	public void LoadTech(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}


	void Start()
	{
		if (!SetMenu.gameHasStarted)
		{
			print("Game Start!");
			SetMenu.menuOn = true;
			SetMenu.gameHasStarted = true;
			SetMenu.masterVolume = 1.0f;
			SetMenu.levelNum = 0;
			SetMenu.levelNames = new string[3];
			SetMenu.levelNames[0] = "KaustabhPotentialScene";
			SetMenu.levelNames[1] = "Level2";
			SetMenu.levelNames[2] = "Level3";
		}
	}
}
