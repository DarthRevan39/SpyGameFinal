using UnityEngine;
using System.Collections;

public class PlayerAmmoController : MonoBehaviour {

    public int bulletSpeed = 10;
    public int damageToGive = 1;
    private GameObject Spy;
    public PlayerHealthManager myManager = new PlayerHealthManager();

    // Use this for initialization
    void Start() {
        Spy = GameObject.Find("Spy");
        if (Spy.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FatEnemy")
        {
            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            Destroy(gameObject);
        }

        if (collision.tag == "SkinnyEnemy")
        {
            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            Destroy(gameObject);
        }

    }

	
	// Update is called once per frame
	void Update ()
    {
        float changeInX = bulletSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(gameObject.transform.position.x + changeInX, transform.position.y, transform.position.z);
        gameObject.transform.position = newPosition;
    }
}
