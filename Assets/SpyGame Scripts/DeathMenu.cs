using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {


    public bool isDead = false;
    public GameObject spy;
    public GameObject deathMenuCanvas;
    // Use this for initialization
    void Start()
    {
        spy = GameObject.Find("Spy");
    }

    // Update is called once per frame
    void Update()
    {
        isDead = spy.GetComponent<PlayerHealthManager>().isDead;
        if (isDead)
        {
            deathMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            deathMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void restart()
    {
        Application.LoadLevel(5);
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
