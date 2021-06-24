using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldIcon : MonoBehaviour
{


    public float speed = 5;


    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
