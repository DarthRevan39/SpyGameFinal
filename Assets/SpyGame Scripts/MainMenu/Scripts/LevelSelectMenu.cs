using UnityEngine;
using System.Collections;

public class LevelSelectMenu : MonoBehaviour {
    public GUIStyle title;
    public Texture backgroundTexture;
    public string titleText;

    void OnGUI()
    {
        //displays a background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "SPYGAME LEVEL SELECT", title);

        //displays buttons
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f), "Level 1"))
        {
            Application.LoadLevel(5);
        }

        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Level 2"))
        {
            Application.LoadLevel(6);
        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .5f, Screen.height * .1f), "Level 3"))
        {
            Application.LoadLevel(7);
        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "Return to Main Menu"))
        {
            Application.LoadLevel(0);
        }


    }
}
