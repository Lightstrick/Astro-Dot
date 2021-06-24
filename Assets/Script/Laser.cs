using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Laser : MonoBehaviour
{
    public int damage = 5;
    public GameObject impactEffect;
    public Rigidbody2D rb;

    


    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void OnTriggerEnter2D (Collider2D hitInfo)
    {

        

        Obstacle obstacle = hitInfo.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            obstacle.TakeDamage(damage);
            
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);



        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);

        BossEnemy bossEnemy = hitInfo.GetComponent<BossEnemy>();
        if (bossEnemy != null)
        {
            bossEnemy.TakeDamage(damage);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);



        OBS_DROP obs = hitInfo.GetComponent<OBS_DROP>();
        if (obs != null)
        {
            obs.TakeDamage(damage);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);


        HealImpact healimpact = hitInfo.GetComponent<HealImpact>();
        if (healimpact != null)
        {
            healimpact.TakeDamage(damage);
            player.Heal(10);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);


        Loot loot = hitInfo.GetComponent<Loot>();
        if (loot != null)
        {
            loot.TakeDamage(damage);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);



    }

    

    



}
