using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    public GameObject FloatingTextPrefab;

    public int health = 200;

    public GameObject deathEffect;

    public GameObject drop;//your item

    


    

    public void OnDestroy() //called, when enemy will be destroyed
    {
        Instantiate(drop, transform.position, drop.transform.rotation); //your dropped item
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            
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


}
