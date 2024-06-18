using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public bool cactus;
    private bool keep;
    // Start is called before the first frame update
    void Start()
    {
        int scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>().score;

        if(cactus)
        {
            keep = (scoreTracker % 20000 > 17500);
        }
        else
        {
            keep = (scoreTracker % 20000 > 5000 && scoreTracker % 40000 <= 7500);
        }

        if(!keep) Destroy(gameObject);
    }
}