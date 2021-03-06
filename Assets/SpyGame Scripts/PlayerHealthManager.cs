﻿using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    
    
    [HideInInspector]
    public bool isDead = false;
    public int lives = 5;
    public GameObject spy = GameObject.Find("Spy");


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lives > 0)
            return;
        else
        {
            GetComponent<PlayerController>().setHealthText();
            isDead = true;
            spy.SetActive(false);
            //DestroyObject(GameObject.Find("Spy"));
        }
	}

    public void removeHealthPoint(int amount)
    {
        lives = lives - amount;
    }

    public void powerUpFullHealth()
    {
        lives = 5;
    }
}
