using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private KeyCode lastHitKey;

    float move;

    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        
        move = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);

        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            
        }
    }
}

