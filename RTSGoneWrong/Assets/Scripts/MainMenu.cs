using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void MenuAction(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
