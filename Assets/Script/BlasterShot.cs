using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;


public class BlasterShot : MonoBehaviour
{
    public float moveSpeed = 30f;

    private float lifeTime;
    private float maxLifetime = 2f;

    private void OnEnable()
    {
        lifeTime = 0f;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifetime)
        {
            BlasterShotPool.Instance.ReturnToPool(this);
        }
    }


}
