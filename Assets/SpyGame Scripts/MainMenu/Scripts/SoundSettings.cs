using UnityEngine;
using System.Collections;

public class SoundSettings : MonoBehaviour {

    public GUIStyle title;
    public GUIStyle input;
    public Texture backgroundTexture;
    public string titleText;

    public float sfxVol = 5;
    public float musicVol = 5;

    void OnGUI()
    {
        //displays a background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .3f, Screen.width * .5f, Screen.height * .1f), "SPYGAME SOUND", title);

        //displays buttons and sliders

        sfxVol = GUI.HorizontalSlider(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width * .3f, Screen.height * .1f), sfxVol, 0.0f, 10.0f);
        GUI.Label(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "SFX: " + sfxVol, input);

        musicVol = GUI.HorizontalSlider(new Rect(Screen.width * .1f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), musicVol, 0.0f, 10.0f);
        GUI.Label(new Rect(Screen.width * .1f, Screen.height * .8f, Screen.width * .5f, Screen.height * .1f), "Music: " + musicVol, input);


            if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * 1f, Screen.width * .5f, Screen.height * .1f), "Return to Options"))
        {
            Application.LoadLevel(2);
        }

        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * 0.85f, Screen.width * .5f, Screen.height * .1f), "Return to Options"))
        {
            Application.LoadLevel(2);
        }


    }
}
