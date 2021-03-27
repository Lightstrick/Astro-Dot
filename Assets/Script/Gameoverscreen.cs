using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameoverscreen : MonoBehaviour
{
    public static bool RestartGame = false;

    public GameObject RestartMenuUI;


    private Player player;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void Update()
    {

        if (GetComponent<Player>().currentHealth <= 0)
        {
            if (RestartGame)
            {
                Restart();
            }
            
        }

    }

    void Restart()
    {
        RestartMenuUI.SetActive(true);
        Time.timeScale = 0f;
        RestartGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
