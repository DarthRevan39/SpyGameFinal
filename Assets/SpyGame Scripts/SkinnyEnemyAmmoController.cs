using UnityEngine;
using System.Collections;

public class SkinnyEnemyAmmoController : MonoBehaviour {

    public float bulletSpeed;
    private GameObject Spy;
    private int damageToGive = 1;
    public float yPos;
    [HideInInspector]
    public Transform targetPosition;
    private float slope;
    private Transform bulletPosition;

    // Use this for initialization
    void Start() {
        Spy = GameObject.Find("Spy");

        if (Spy.transform.position.x < transform.position.x)
        {
            bulletSpeed = -bulletSpeed;
        }
        yPos = gameObject.transform.position.y;
        bulletPosition = gameObject.transform;
        slope = (Spy.transform.position.y - bulletPosition.transform.position.y) / (Spy.transform.position.x - bulletPosition.transform.position.x);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealthManager>().removeHealthPoint(damageToGive);
            Destroy(gameObject);
        }

        if (collision.tag == "ground")
        {
            Destroy(gameObject);
        }
    }

	
	// Update is called once per frame
	void Update ()
    {
        float changeInX = bulletSpeed * Time.deltaTime;
        yPos = yPos + changeInX*slope*0.5f;
        
        Vector3 newPosition = new Vector3(gameObject.transform.position.x + changeInX, yPos, transform.position.z);
        gameObject.transform.position = newPosition;
    }
}
