using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShootPooled : MonoBehaviour
{
    [SerializeField]

    public HomingMissile blasterShotPrefab;


    private Queue<HomingMissile> blasterShots = new Queue<HomingMissile>();

    public static MissileShootPooled Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddShots(10);
    }


    public HomingMissile Get()
    {
        if (blasterShots.Count == 0)
        {
            AddShots(1);
        }

        return blasterShots.Dequeue();
    }

    private void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            HomingMissile blasterShot = Instantiate(blasterShotPrefab);
            blasterShot.gameObject.SetActive(false);
            blasterShots.Enqueue(blasterShot);
        }





    }

    public void ReturnToPool(HomingMissile blasterShot)
    {
        blasterShot.gameObject.SetActive(false);
        blasterShots.Enqueue(blasterShot);
    }
}
