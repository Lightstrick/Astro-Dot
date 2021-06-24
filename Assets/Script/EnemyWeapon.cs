using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float moveSpeed = 30f;

    private float lifeTime;

    private float maxLifetime = 3.5f;


    //new
    public int damage = 10;

    public GameObject impactEffect;

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

        //end new

    

    private void OnEnable()
    {
        lifeTime = 0f;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifetime)
        {
            EnemyBlasterShotPooled.Instance.ReturnToPool(this);
        }

    }
}
