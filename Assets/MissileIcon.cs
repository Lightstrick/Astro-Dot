using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileIcon : MonoBehaviour
{
    
    public float speed = 5;


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
