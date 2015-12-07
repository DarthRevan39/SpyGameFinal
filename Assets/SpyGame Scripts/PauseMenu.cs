using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseMenuCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
	}

    public void resume()
    {
        isPaused = false;

    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }

    public void options()
    {
        Application.LoadLevel(2);
    }

    public void exit()
    {
        Application.Quit();
    }
}
