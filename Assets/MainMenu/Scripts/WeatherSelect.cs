using UnityEngine;
using System.Collections;

public class WeatherSelect : MonoBehaviour {

    public GUIStyle title;
    public GUIStyle input;
    public Texture backgroundTexture;
    public string titleText;
    private string zipCode = "ZIP";

    void OnGUI()
    {
        //displays a background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "SPYGAME WEATHER", title);

        //displays buttons and text field
        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f), "Enter Zip Code for in Game Weather", input);
        zipCode = GUI.TextField(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), zipCode, 5, input);
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .5f, Screen.height * .1f), "Return to Options"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "Return to Main Menu"))
        {
            Application.LoadLevel(0);
        }


    }
}
