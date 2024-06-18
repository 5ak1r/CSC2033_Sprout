using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
    /*
     * Class to handle all switching between scenes.
     */
{
    public TransitionHandler transitionHandler;
    public bool transitionOnSceneOpen; // Set value in the inspector if scene should Open Transition when loaded

    public void Awake()
    {
        if(transitionOnSceneOpen)
        {
            transitionHandler.openTransition();
        }
    }
    public void LoadMain() // Main Game Scene
    {
        GameObject old = GameObject.Find("ScoreTracker");
        Destroy(old);
        SceneManager.LoadScene("Main");
    }

    public void LoadGameOver() // Game Over Scene
    {
        SceneManager.LoadScene("GameOver");

    }


}
