using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    
    [HideInInspector]
    public int score;

	// Use this for initialization
	void Start () {

        score = 0;
	}

    // Update is called once per frame
    void Update () {
	}

    public void addPointAmount(int amount)
    {
        score = score + amount;
    }

    public int getScore()
    {
        return score;
    }
}
