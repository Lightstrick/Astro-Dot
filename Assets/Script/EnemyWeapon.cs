using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float moveSpeed = 30f;

    private float lifeTime;
    private float maxLifetime = 3.5f;

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
