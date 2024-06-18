using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//score display for game screen
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public ScoreTracker scoreTracker;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreTracker.score.ToString();
    }
}
