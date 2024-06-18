using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAlteration : MonoBehaviour
{
    public Sprite field;
    public Sprite snow;
    public Sprite volcanic;
    public Sprite desert;
    private int score;
    private SpriteRenderer sr;
    private GameObject sprout;
    private float sprout_x;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sprout = GameObject.FindWithTag("Sprout");
    }

    private void Update()
    {
        score = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>().score;
        if(sprout) sprout_x = sprout.GetComponent<Rigidbody2D>().position.x;

        if(score % 20000 < 5000 && transform.position.x > sprout_x)
        {
            sr.sprite = field;
        }
        else if(score % 20000 < 7500 && transform.position.x > sprout_x)
        {
            sr.sprite = snow;
        } 
        else if(score % 20000 < 15000 && transform.position.x > sprout_x)
        {
            sr.sprite = volcanic;
        }
        else if(score % 20000 < 20000 && transform.position.x > sprout_x)
        {
            sr.sprite = desert;
        }
    }

}
