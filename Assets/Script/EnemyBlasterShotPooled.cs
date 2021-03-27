using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlasterShotPooled : MonoBehaviour
{
    [SerializeField]

    public EnemyWeapon blasterShotPrefab;


    private Queue<EnemyWeapon> blasterShots = new Queue<EnemyWeapon>();

    public static EnemyBlasterShotPooled Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddShots(150);
    }


    public EnemyWeapon Get()
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
            EnemyWeapon blasterShot = Instantiate(blasterShotPrefab);
            blasterShot.gameObject.SetActive(false);
            blasterShots.Enqueue(blasterShot);
        }



    }

    public void ReturnToPool(EnemyWeapon blasterShot)
    {
        blasterShot.gameObject.SetActive(false);
        blasterShots.Enqueue(blasterShot);
    }
}
