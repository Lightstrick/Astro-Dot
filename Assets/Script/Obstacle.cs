﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Obstacle : MonoBehaviour
{

    public GameObject FloatingTextPrefab;

    public int health = 30;
    public int damage = 10;
    public float speed = 5;

    public GameObject effect;
    public GameObject deathEffect;
    [SerializeField] private int scoreValue = 5;
    

    private Player player;

    

    void Start()
    {
        player = Player.Instance;
    }


    public void TakeDamage (int damage)
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
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            go.GetComponent<TextMesh>().text = damage.ToString();
        }
    }
    
    private void Update()
    { 
        transform.Translate(Vector2.down * speed * Time.deltaTime);
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
            player.currentHealth -= damage;
            player.Damage(5);
            Destroy(gameObject);
        }

    }

}
