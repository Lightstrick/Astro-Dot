using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public void AccumulateScore ()
    {
        var score = ScoreScript.scoreValue;
        UserData.Current?.AccumulateScore(score);
        ScoreScript.ResetScore();
    }
}
