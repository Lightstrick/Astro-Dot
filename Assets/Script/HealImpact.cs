using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealImpact : MonoBehaviour
{

    public int health = 30;
    public float speed = 5;
    public GameObject effect;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

            Die();
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
            Destroy(gameObject);

        }
    }
}        