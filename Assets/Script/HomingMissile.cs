using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    private Transform target;

    private Rigidbody2D rb;

    public float speed = 5f;

    public float rotateSpeed = 200f;

    //new for lifetime
    private float lifeTime;
    private float maxLifetime = 2f;

    private void OnEnable()
    {
        lifeTime = 0f;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifetime)
        {
            MissileShootPooled.Instance.ReturnToPool(this);
        }
    }

    //new end for lifetime

    //new
    public int damage = 15;
    public GameObject impactEffect;
    private Player player;
    //end new
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Enemy.AvailableEnemies != null && Enemy.AvailableEnemies.Count > 0)
        {
            target = Enemy.AvailableEnemies[0].transform;
        }

        /*var targetObject = GameObject.FindGameObjectWithTag("Enemy");

        if (targetObject != null)
        {
            target = targetObject.transform;
        }*/

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;
        }
        
        rb.velocity = transform.up * speed;
    }

    //new
    void OnTriggerEnter2D(Collider2D hitInfo)
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
    //new end
}
