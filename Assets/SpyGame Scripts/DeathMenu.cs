using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {


    public bool isDead;
    public GameObject spy;
    public GameObject deathMenuCanvas;
    public int counter;
    public int levelSelect;
    // Use this for initialization
    void Start()
    {
        spy = GameObject.Find("Spy");
        counter = 0;
        deathMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isDead = spy.GetComponent<PlayerHealthManager>().isDead;
        if (isDead)
        {

            deathMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            if (counter == 0)
            {
                deathMenuCanvas.SetActive(true);
                Time.timeScale = 0f;
                Vector3 newPosition = new Vector3(spy.transform.position.x - 1000, spy.transform.position.y, transform.position.z);
                spy.transform.position = newPosition;
                counter++;
            }
           
        }
        else
        {
            if (counter == 1)
            {
                deathMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
                Vector3 newPosition = new Vector3(spy.transform.position.x + 1000, spy.transform.position.y, transform.position.z);
                spy.transform.position = newPosition;
            }
            deathMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void restart()
    {
        Application.LoadLevel(levelSelect);

    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }


    public void exit()
    {
        Application.Quit();
    }
}
