using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //cactus shoots needle bullet when it comes into view
    private void OnBecameVisible() {
        gameObject.GetComponent<Renderer>().enabled = true;
        CameraMovement cameraMovement = GameObject.Find("Game Manager").GetComponent<CameraMovement>();
        rb.velocity = new Vector2(-cameraMovement.cameraSpeed*1.2f, 0);
    }
}
