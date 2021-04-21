using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject FloatingTextPrefab;
    
    public int health = 200;
    public int damage = 10;
    

    public GameObject effect;
    public GameObject deathEffect;
    [SerializeField] private float angleOffset = 90;

    [Space]
    [SerializeField] private int scoreValue = 5;

    private Player player;

    public GameObject drop;//your coin
    //public GameObject drop2;

    private GameObject damageContainer;
    

    private void OnDestroy() //called, when enemy will be destroyed
    {
        if(damageContainer != null)
        {
            Destroy(damageContainer);
        }
        Instantiate(drop, transform.position, drop.transform.rotation); //your dropped coin
        //Instantiate(drop2, transform.position, drop2.transform.rotation);
        
    }

    void Start()
    {

    }

    private void Update ()
    {
        if(player != null)
        {
            var dir = player.transform.position - transform.position;
            dir.z = 0;
            dir.Normalize();
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + angleOffset, Vector3.forward);
        }
        else
        {
            player = Player.Instance;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            ScoreScript.AddScore(scoreValue);
        }

        //Trigger floting text
        if (FloatingTextPrefab && damage > 0)
        {
            if(damageContainer == null)
            {
                damageContainer = new GameObject(transform.name + "_Damage_Container");
            }

            damageContainer.transform.position = transform.position;
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, damageContainer.transform);
            go.GetComponent<TextMesh>().text = damage.ToString();
        }
    }


    void Die()
    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.CompareTag("Player"))
        {

            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().currentHealth -= damage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            player.Damage(5);
        }


    }
}
