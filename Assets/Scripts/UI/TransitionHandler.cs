using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionHandler : MonoBehaviour
{
    //Prefab
    public GameObject wipeCoverPrefab;


    public void closeTransition(string sceneToLoad)
    // triggered at player death and when changing scenes
    {
        Vector2 startPos = new Vector2(-950, 0);
        Vector2 endPos = new Vector2(57,0);


        // Instantiate Wipe prefab
        GameObject instance = Instantiate(wipeCoverPrefab, transform);
        //// Set instance values
        instance.GetComponent<WipeTransitionBehaviour>().startPos = startPos;
        instance.GetComponent<WipeTransitionBehaviour>().endPos = endPos;
        instance.GetComponent<WipeTransitionBehaviour>().sceneSwitch = true;
        instance.GetComponent<WipeTransitionBehaviour>().sceneToLoad = sceneToLoad;




    }
    public void openTransition()
    // Triggered when new scene loaded
    {

        Vector2 startPos = new Vector2(90,0);
        Vector2 endPos = new Vector2(-950, 0);

        // Instantiate prefab
        GameObject instance = Instantiate(wipeCoverPrefab, transform);
        // Set instance values
        instance.GetComponent<WipeTransitionBehaviour>().startPos = startPos;
        instance.GetComponent<WipeTransitionBehaviour>().endPos = endPos;
        instance.GetComponent<WipeTransitionBehaviour>().sceneSwitch = false;
    }


}