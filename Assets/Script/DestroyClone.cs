using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{

    public float DestroyTime = 1f;
    
    void Start()
    {
        StartCoroutine("DestroyMe");
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
}
