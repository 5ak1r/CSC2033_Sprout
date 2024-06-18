using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WipeTransitionBehaviour : MonoBehaviour
/*
* Instantiated in TransitionHandler -- Attached to WipeCoverPrefab
*/
{
    // Pass in at instantiation
    public Vector2 startPos;
    public Vector2 endPos; 
    public bool sceneSwitch; // Boolean to decide whether to switch scene at the end of transition
    public string sceneToLoad; // The new scene to load once the transition over

    public void Start()
    {
        transform.localPosition = startPos;
    }
    public void FixedUpdate()
    {
        // Moves the GameObject from it's current position to destination over time
        transform.localPosition = Vector2.Lerp(transform.localPosition, endPos, Time.deltaTime *4);

        // Check distance -- if close, destroy object and end transition
        float distance = Vector2.Distance(transform.localPosition, endPos);
        if(distance <= 20)
        {
            if(sceneSwitch)
            // Only change scene if boolean True
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            //this.gameObject.SetActive(false);
        }
    }
}
