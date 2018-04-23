using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void MenuAction(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	void Start()
	{
		if (!SetMenu.gameHasStarted)
		{
			print("Game Start!");
			SetMenu.menuOn = true;
			SetMenu.gameHasStarted = true;
			SetMenu.masterVolume = 1.0f;
		}
	}
}
