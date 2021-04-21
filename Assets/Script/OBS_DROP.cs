using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBS_DROP : MonoBehaviour
{

    public GameObject FloatingTextPrefab;

    public int health = 30;
    public int damage = 10;
    public float speed = 5;
    [SerializeField] private int scoreValue = 10;

    public GameObject effect;
    public GameObject deathEffect;

    

    private Player player;

    public GameObject drop;//your coin

    private void OnDestroy() //called, when enemy will be destroyed
    {
        Instantiate(drop, transform.position, drop.transform.rotation); //your dropped coin
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
            other.GetComponent<Player>().currentHealth -= damage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            player.Damage(5);
        }


    }




}
