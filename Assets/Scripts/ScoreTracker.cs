using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//keeps track of score
public class ScoreTracker : MonoBehaviour
{
    public int score;
    public Sprout sprout;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        score = 0;
    }
    void Update()
    {
        if(sprout) score++;
    }

}