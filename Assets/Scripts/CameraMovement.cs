using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraSpeed;

    // Update is called once per frame
    //moves the camera to give the illusion of player movement, increases speed with time
    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        cameraSpeed += 1e-6f;
    }
}
