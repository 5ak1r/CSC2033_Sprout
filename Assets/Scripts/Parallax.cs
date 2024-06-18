using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Material field1;
    public Material field2;
    public Material snow_mountain_transition;
    public Material snow_mountain;
    public Material lava_mountain;
    public Material lava_cave;
    public Material cave;
    public Material forest;
    public Material desert;
    public CameraMovement cameraMovement;
    public Renderer backgroundRenderer;
    private int score;
    private Material newMaterial;
    private Vector2 currentOffset;

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>().score;
        currentOffset = backgroundRenderer.material.mainTextureOffset;

        if(score % 20000 < 2500)
        {
            newMaterial = field1;
        }
        else if(score % 20000 < 5000)
        {
            newMaterial = field2;
        }
        else if(score % 20000 < 7500)
        {
            newMaterial = snow_mountain;
        }
        else if(score % 20000 < 10000)
        {
            newMaterial = lava_mountain;
        }
        else if(score % 20000 < 12500)
        {
            newMaterial = lava_cave;
        }
        else if(score % 20000 < 15000)
        {
            newMaterial = cave;
        }
        else if(score % 20000 < 17500)
        {
            newMaterial = forest;
        }
        else if(score % 20000 < 20000)
        {
            newMaterial = desert;
        }


        if(backgroundRenderer.material != newMaterial && newMaterial != null) backgroundRenderer.material = newMaterial;
        if(newMaterial == null) backgroundRenderer.enabled = false;
        if(newMaterial != null && !backgroundRenderer.enabled) backgroundRenderer.enabled = true;

        backgroundRenderer.material.mainTextureOffset += currentOffset + new Vector2((cameraMovement.cameraSpeed / (5*transform.position.z)) * Time.deltaTime, 0f);
    }

}