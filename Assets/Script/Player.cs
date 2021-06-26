using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{


    public static Player Instance { get; private set; }

    private Player player;

    [SerializeField]
    private GameObject shield;
    private bool shielded;

    [SerializeField]
    private GameObject missile; //new
    private bool missileGo;

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject deathEffect;

    public static bool gameOver;
    public GameObject RestartMenu;

   
    void NoShield()
    {
        shield.SetActive(false);
        shielded = false;
    }

    //new
    void NoMissile()
    {
        missile.SetActive(false);
        missileGo = false;
    }

    //end new

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

        
        
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        gameOver = false;
        
    }

    public void Damage(int damage)
    {
        
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            gameOver = true;
            RestartMenu.SetActive(true);
        }
    }

    public void Heal(int dmg)
    {
        currentHealth += dmg;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
        }

        //new
        if (other.CompareTag("Shield"))
        {
            shield.SetActive(true);
            shielded = true;
            //code for turning off shield
            Invoke("NoShield", 4f);

            Destroy(other.gameObject);

        }

        if (other.CompareTag("Missile"))
        {
            missile.SetActive(true);
            missileGo = true;

            Destroy(other.gameObject);
        }

    }

    


    void Die()
    {
        GameManager.Instance.AccumulateScore();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    
    // Update is called once per frame
    private void Update()
    {

        
        
        if (Input.touchCount > 0)
        {
            

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }

        if (currentHealth > 100)
        {
            currentHealth = 100;
        }



    }

    

}

