using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform Target;
    public float MinModifier = 7;
    public float MaxModifier = 11;

    Vector3 velocity = Vector3.zero;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
    }
}
