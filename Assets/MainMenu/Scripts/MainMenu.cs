//<summary>
//Main Menu
//Attached to main camera
//</summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public GUIStyle title;
    public Texture backgroundTexture;
    public string titleText;

    void OnGUI()
    {
        //displays a background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "SPYGAME", title);

        //displays buttons
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f), "Play Game"))
        {
            Application.LoadLevel(5);
        }

        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Level Select"))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .5f, Screen.height * .1f), "Options"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "Exit Game"))
        {
            Application.Quit();
        }


    }
}
