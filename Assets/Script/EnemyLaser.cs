using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public int damage = 10;
    
    public GameObject impactEffect;
    //public Rigidbody2D rb;

   

    private Enemy enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {



        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(damage);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
