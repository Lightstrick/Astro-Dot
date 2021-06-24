using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePooled : MonoBehaviour
{
    [SerializeField]
    private float refireRate = 2f;

    private float fireTimer = 0;


    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= refireRate)
        {
            fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        var shot = MissileShootPooled.Instance.Get();
        shot.transform.position = transform.position;
        shot.transform.rotation = transform.rotation;
        shot.gameObject.SetActive(true);
    }
}
