//<summary>
//Main Menu
//Attached to main camera
//</summary>

using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    
    public Texture backgroundTexture;
    
    void OnGUI()
    {
        //displays a background texture
        


        //displays buttons
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width*.5f, Screen.height * .1f), "Play Game"))
        {

        }

        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Level Select"))
        {

        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .5f, Screen.height * .1f), "Options"))
        {

        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "Exit Game"))
        {

        }

    }
}
