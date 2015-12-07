using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    [HideInInspector]
    public int enemyHealth;
    public int pointsOnDeath;
    private GameObject Spy;

	// Use this for initialization
	void Start () {

        Spy = GameObject.Find("Spy");

        float value = Random.value;

        if (value < 0.2)
            enemyHealth = 1;
        else if (value < 0.4)
            enemyHealth = 2;
        else if (value < 0.6)
            enemyHealth = 3;
        else if (value < 0.8)
            enemyHealth = 4;
        else if (value < 0.99)
            enemyHealth = 5;
        else
            enemyHealth = 10;
   }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Spy.GetComponent<ScoreManager>().addPointAmount(pointsOnDeath);
            Destroy(gameObject);
        }
	}

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
