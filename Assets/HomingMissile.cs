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
}
