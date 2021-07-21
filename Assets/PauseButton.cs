using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPaused = false;

    public GameObject pauseMenuUI;

    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }

        else
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
