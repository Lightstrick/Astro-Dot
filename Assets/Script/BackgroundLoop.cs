using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    public float speed = 10f;
    public float clamppos;

    [HideInInspector] public Vector3 StartPosition;

   
    

    void Start()
    {
        StartPosition = transform.position;
    }

    
    
    void FixedUpdate()
    {
        float NewPosition = Mathf.Repeat(Time.time * speed, clamppos);
        transform.position = StartPosition + Vector3.down * NewPosition;                
    }

    

}
