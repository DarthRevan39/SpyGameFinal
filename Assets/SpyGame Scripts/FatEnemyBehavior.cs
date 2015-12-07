using UnityEngine;
using System.Collections;

public class FatEnemyBehavior : MonoBehaviour {

    private Vector2 position;
    private float xPos;
    [HideInInspector]
    private GameObject Spy;
    private int updateCount;
    private int updateTime;
    public GameObject potato;
    private bool isThrowing;
    private Animator fatEnemy;

    // Use this for initialization
    void Start()
    {
        fatEnemy = GetComponent<Animator>();
        Spy = GameObject.Find("Spy");
        updateTime = 120;
        updateCount = 30;
    }

    // Update is called once per frame
    void Update()
    {

        fatEnemy.SetBool("isThrowing", isThrowing);
        position = transform.position;
        xPos = this.position.x;

        if (Spy.transform.position.x > this.position.x)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else if (Spy.transform.position.x < this.position.x)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }

        if (Mathf.Abs(this.position.x - Spy.transform.position.x) < 20)
        {
            Vector3 potatoSpawn = transform.position;
            if (Spy.transform.position.x > this.position.x)
                potatoSpawn.x = potatoSpawn.x + 1;
            else
                potatoSpawn.x = potatoSpawn.x - 1;

            if (updateCount % updateTime == 0)
            {
                isThrowing = true;
                fatEnemy.SetBool("isThrowing", isThrowing);
                Instantiate(potato, potatoSpawn, transform.rotation);
                Instantiate(potato, potatoSpawn, transform.rotation);
                updateCount = 0;
            }
        }
        updateCount++;
        isThrowing = false;
    }
}

    

