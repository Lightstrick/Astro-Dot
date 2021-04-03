﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool moveRight;


    void Start()
    {
        moveSpeed = 1f;
        moveRight = true;
    }


    void Update()
    {
        if (transform.position.x > 0.3f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -0.3f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    } 

}