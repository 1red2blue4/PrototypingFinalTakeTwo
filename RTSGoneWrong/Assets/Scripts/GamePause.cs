using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{

    Texture2D tintTexture;
    Color tintCOlor;
    GUIStyle guiStyle;

    //Set colour to red t.SetPixel( 0, 0, Color.white );

    // Use this for initialization
    void Start()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        tintTexture = new Texture2D(1, 1);
        tintCOlor = new Color(1, 0, 0, 0.2f); // Opaque red
        
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
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

    void OnGUI()
    { 
        if (Time.timeScale == 0)
        {
            GUI.color = tintCOlor;

            // Draw fade 
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tintTexture, ScaleMode.StretchToFill);
            float w = 250.0f; 
            float h = 300.0f;      
            //Can these numbers be not constants?
            Rect rect = new Rect(((Screen.width/2) - 180), ((Screen.height / 2) -100), w, h);
            GUI.Label(rect, "Game Paused", guiStyle);
        }
    }
}
