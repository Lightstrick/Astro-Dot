using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public float startTimeBtwShots;
    private float timeBtwShots;
    
    
   // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;

    }
   // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
