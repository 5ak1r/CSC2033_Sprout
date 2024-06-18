using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    //Destroy platforms and eneies when they collide with this object; reduce lag by removing game objects when no longer needed
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Platform")
        || other.gameObject.CompareTag("Fire")
        || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
        
}
