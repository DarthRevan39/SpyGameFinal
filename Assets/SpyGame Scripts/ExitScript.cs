using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public int levelSelect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Application.LoadLevel(levelSelect);
        }
    }
}
