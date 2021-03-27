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



    private Player player;


    public GameObject drop;//your coin
    //public GameObject drop2;
    

    private void OnDestroy() //called, when enemy will be destroyed
    {
        Instantiate(drop, transform.position, drop.transform.rotation); //your dropped coin
        //Instantiate(drop2, transform.position, drop2.transform.rotation);
        
    }



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            ScoreScript.scoreValue += 5;
        }

        //Trigger floting text
        if (FloatingTextPrefab && damage > 0)
        {
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
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
