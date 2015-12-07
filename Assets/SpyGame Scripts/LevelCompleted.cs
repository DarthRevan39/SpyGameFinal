using UnityEngine;
using System.Collections;

public class LevelCompleted : MonoBehaviour
{
    public GameObject spy;
    public GameObject levelCompleteMenuCanvas;
    public int levelSelect;
    public int currentLevel;
    private GameObject exitSign;
    // Use this for initialization
    void Start()
    {
        spy = GameObject.Find("Spy");
        levelCompleteMenuCanvas.SetActive(false);
        exitSign = GameObject.Find("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if (exitSign.GetComponent<ExitScript>().levelComplete == true)
        {
            levelCompleteMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            levelCompleteMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void restart()
    {
        Application.LoadLevel(currentLevel);

    }

    public void goToNextLevel()
    {
        Application.LoadLevel(levelSelect);
    }


    public void exit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }
}
