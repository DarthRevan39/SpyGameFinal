using UnityEngine;
using System.Collections;

public class PotatoController : MonoBehaviour
{
    private GameObject Spy;
    private Transform spyPosition;
    [HideInInspector]
    private int damageToGive = 1;
    private float potatoSpeed;

    // Use this for initialization
    void Start()
    {
        Spy = GameObject.Find("Spy");
        spyPosition = Spy.transform;
        choosePotatoSpeed();

        if (Spy.transform.position.x < transform.position.x)
        {
            potatoSpeed = -potatoSpeed;
        }
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
    void Update()
    {
        float changeInX = potatoSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(gameObject.transform.position.x + changeInX, transform.position.y, transform.position.z);
        gameObject.transform.position = newPosition;
    }

    public void choosePotatoSpeed()
    {
        float value = Random.value;
        potatoSpeed = value * 20 + 7;
    }
}
