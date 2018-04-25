using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{

    Texture2D tintTexture;
    Color tintCOlor;
    Color progressiveWhiteScreen;
    GUIStyle guiStyle;

    public bool isEnemyDead;
    public bool isPlayerDead;
    private bool gameEnded;

    //Set colour to red t.SetPixel( 0, 0, Color.white );

    // Use this for initialization
    void Start()
    {
        gameEnded = false;
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        tintTexture = new Texture2D(1, 1);
        tintCOlor = new Color(1, 0, 0, 0.2f); // Opaque red

        progressiveWhiteScreen = new Color(1f, 1f, 1f, 0.05f);
        isEnemyDead = false;
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (!gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                if (Time.timeScale == 1)
                {
                    Debug.Log("game paused");
                    Time.timeScale = 0;
                }
                else if (Time.timeScale == 0)
                {
                    Debug.Log("unpaused");
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Load whatever scene
            }
        }
    }

    void OnGUI()
    { 
        if (Time.timeScale == 0)
        {
            GUI.color = tintCOlor;
            // Draw fade 
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tintTexture, ScaleMode.StretchToFill);

            Rect rect = new Rect((Screen.width / 2) - (200 / 2),
                                (Screen.height / 2) - (200 / 2),
                                200,
                                200);
            GUI.Label(rect, "Game Paused", guiStyle);
        }

        if (isEnemyDead || isPlayerDead)
        {
            if (!gameEnded)
            {
                guiStyle.fontSize = 20;
                gameEnded = true;

            }
            progressiveWhiteScreen.a += 0.01f;
            GUI.color = Color.white;
            // Draw fade 
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tintTexture, ScaleMode.StretchToFill);

            Rect rect = new Rect((Screen.width / 2) - (200 / 2),
                                (Screen.height / 2) - (200 / 2),
                                200,
                                200);
            if (isPlayerDead)
            {
                GUI.Label(rect, "You Lose", guiStyle);
            }
            else
            {
                GUI.Label(rect, "You Win", guiStyle);
            }
            guiStyle.fontSize += 1;
            if (guiStyle.fontSize > 100)
            {
                guiStyle.fontSize = 100;
            }
        }
    }
}
