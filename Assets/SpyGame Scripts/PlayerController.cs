using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using WReader;
using System;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{
    //Player handling
    public float speed = 10;
    public float acceleration = 100;
    public Vector2 position;
    public LayerMask GroundLayers;
    public float JumpSpeed = 100f;
    public Text scoreText;
    public Text healthText;
    public GameObject muricaBullet;
    private int updateCounter;
    private int scoreColorCounter;
    private bool isShooting;
    private Animator player;
    public Text weatherText;
    public Text cityText;
    private GameObject[] clouds;
    public GameObject snow;
    public GameObject rain;

    private Transform m_GroundCheck;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;
    [HideInInspector]
    public PlayerHealthManager myHealthManager;
    private PlayerPhysics playerPhysics;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Animator>();
        setScoreText();
        setHealthText();
        playerPhysics = GetComponent<PlayerPhysics>();
        m_GroundCheck = transform.FindChild("GroundCheck");
        updateCounter = 0;

        //Weather
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
        snow = GameObject.Find("Snow");
        rain = GameObject.Find("Rain");
        weatherText.text = "" + WeatherGrab.GetConditions(WeatherGrab.GetZip());
        try
        {
            if (weatherText.text.Contains("Clear"))
            {
                for (int i = 0; i < clouds.Length; i++)
                {
                    clouds[i].SetActive(false);
                }
                if (snow != null)
                    snow.SetActive(false);
                if (rain != null)
                    rain.SetActive(false);

            }
            else if (weatherText.text.Contains("Snow") || weatherText.text.Contains("Sleet") || weatherText.text.Contains("Ice"))
            {
                if (snow != null)
                snow.SetActive(true);

                if (rain != null)
                rain.SetActive(false);
            }
            else if (weatherText.text.Contains("Rain") || weatherText.text.Contains("storm"))
            {
                if (snow != null)
                snow.SetActive(false);

                if (rain != null)
                rain.SetActive(true);
            }
            else
            {
                if (snow != null)
                snow.SetActive(false);

                if (rain != null)
                rain.SetActive(false);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            cityText.text = e.Message;
            return;
        }
        cityText.text = "" + WeatherGrab.GetCity(WeatherGrab.GetZip());
          

    }

    // Update is called once per frame
    void Update()
    {
        player.SetBool("isShooting", isShooting);
        player.SetFloat("Speed", Mathf.Abs(currentSpeed));
        //Controlling the movement.
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = incrementTowards(currentSpeed, targetSpeed, acceleration);

        amountToMove = new Vector2(currentSpeed, 0);
        playerPhysics.Move(amountToMove * Time.deltaTime);

        //Change animation's reflection depending on direction heading.
        if (currentSpeed > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
        else if (currentSpeed < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        position = transform.position;

        //Jump Control
        if(Input.GetButtonDown("Jump"))
        {
            bool isGrounded = Physics2D.OverlapPoint(m_GroundCheck.position, GroundLayers);         
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            }
            /*
            if (WeatherGrab.GetConditions("31204").Contains("Cloudyz"))
            {

                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed*4, ForceMode2D.Impulse);
            }
            */
        }

        //Fire Gun Control
        if (Input.GetButtonDown("Fire") && (updateCounter > 35))
        {
            isShooting = true;
            player.SetBool("isShooting", isShooting);
            Instantiate(muricaBullet, transform.position, transform.rotation);
            updateCounter = 0;
        }

        //Update the health text.
        setHealthText();
        setScoreText();
        updateCounter++;
        scoreColorCounter++;               
        isShooting = false;
    }


    private float incrementTowards(float n, float target, float a)
    {
        if (n == target)
            return n;
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    public void setScoreText()
    {
        if (scoreColorCounter < 60)
            scoreText.color = Color.red;
        else if (scoreColorCounter < 120)
            scoreText.color = Color.white;
        else if (scoreColorCounter < 180)
            scoreText.color = Color.blue;
        else
            scoreColorCounter = 0;
            
        scoreText.text = "Score: " + GetComponent<ScoreManager>().getScore().ToString();
    }

    public void setHealthText()
    {
        GameObject Spy = GameObject.Find("Spy");
        healthText.text = "Lives: " + Spy.GetComponent<PlayerHealthManager>().lives.ToString();
        switch(Spy.GetComponent<PlayerHealthManager>().lives)
        {
            case 1:
                healthText.color = Color.red;
                break;
            case 2:
                healthText.color = Color.yellow;
                break;
            case 3:
                healthText.color = Color.yellow;
                break;
            case 4:
                healthText.color = Color.green;
                break;
            case 5:
                healthText.color = Color.green;
                break;
            default:
                healthText.color = Color.red;
                Spy.GetComponent<PlayerHealthManager>().lives = 0;
                break;
        }
    }

}
