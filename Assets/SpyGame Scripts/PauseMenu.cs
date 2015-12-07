using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject Spy = GameObject.Find("Spy");
   // public float xPos;
   // public float tempXpos;
    public int counter;
	// Use this for initialization
	void Start () {
        counter = 0;
        pauseMenuCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(isPaused)
        {
            
            if (counter == 0)
            {
                //xPos = Spy.transform.position.x;
                counter++;
                Vector3 newPosition = new Vector3(Spy.transform.position.x - 1000, Spy.transform.position.y, transform.position.z);
                Spy.transform.position = newPosition;
                //Spy.GetComponent<Rigidbody2D>()
                pauseMenuCanvas.SetActive(true);
                Time.timeScale = 0f;
                Spy.SetActive(false);
            }
            //pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            if (counter == 1)
            {
                Vector3 newPosition2 = new Vector3(Spy.transform.position.x + 1000, Spy.transform.position.y, transform.position.z);
                Spy.transform.position = newPosition2;
                pauseMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
                Spy.SetActive(true);
                counter = 0;
            }
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
