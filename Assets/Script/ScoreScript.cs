using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue { get; private set; }
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();
    }

    public static void AddScore (int score)
    {
        scoreValue += score;
    }

    /// <summary>
    /// Resets the scoreValue.
    /// This should only be called after accumulating the score
    /// </summary>
    public static void ResetScore ()
    {
        scoreValue = 0;
    }
}
