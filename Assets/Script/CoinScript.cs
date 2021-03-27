using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    //public GameObject effect;
    public float speed = 3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("CoinCountFollow"))
        {

            //Instantiate(effect, transform.position, Quaternion.identity);
            ScoreCoin.coinValue += 1;
            Destroy(gameObject);
        }

    }
}