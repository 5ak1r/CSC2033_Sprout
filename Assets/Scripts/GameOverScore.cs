using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//score display for game screen
public class GameOverScore : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        int scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>().score;
        Destroy(GameObject.Find("ScoreTracker"));
        text.text = "Score: " + scoreTracker.ToString();
    }
}
