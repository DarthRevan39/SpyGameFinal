using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public int levelSelect;
    public bool levelComplete;

	// Use this for initialization
	void Start () {

        levelComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelComplete = true;
        }
    }
}
