using UnityEngine;
using System.Collections;

public class SkinnyEnemyBehavior : MonoBehaviour
{
    public int updateTime;
    
    [HideInInspector]
    public Vector2 position;
    [HideInInspector]
    public float xPos;
    private GameObject Spy;
    [HideInInspector]
    public GameObject bullet;
    private int updateCount = 0;
    private bool isShooting;
    private Animator skinnyEnemy;
    
    // Use this for initialization
    void Start()
    {
        skinnyEnemy = GetComponent<Animator>();
        Spy = GameObject.Find("Spy");
        updateTime = GetNumber();
    }

    // Update is called once per frame
    void Update()
    {
        skinnyEnemy.SetBool("isShooting", isShooting);
        position = transform.position;
        xPos = this.position.x;

        if (Spy.transform.position.x > this.position.x)
        {
            transform.localScale = new Vector3(-6, 6, 1);
        }
        else if (Spy.transform.position.x < this.position.x)
        {
            transform.localScale = new Vector3(6, 6, 1);
        }
        updateCount++;


        if (Mathf.Abs(this.position.x - Spy.transform.position.x) < 20)
        {

            Vector3 bulletSpawn = transform.position;
            if (Spy.transform.position.x > this.position.x)
                bulletSpawn.x = bulletSpawn.x + 1;
            else
                bulletSpawn.x = bulletSpawn.x - 1;

            if (updateCount % updateTime == 0)
            {
                isShooting = true;
                skinnyEnemy.SetBool("isShooting", isShooting);
                Instantiate(bullet, bulletSpawn, transform.rotation);
                updateCount = 0;
            }
        }
        isShooting = false;
    }
    public int GetNumber()
    {
        return (int) ((Random.value + 1) * 100);
    }
}
