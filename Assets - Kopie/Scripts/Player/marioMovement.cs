using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marioMovement : MonoBehaviour
{



    public float speed = 1.0f;
    public float jumpSpeed = 0.5f;
    public LayerMask groundLayer;

    private Transform gCheck;
    public Rigidbody2D rb;

    void Start()
    {
        gCheck = transform.Find("GCheck");
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        float mSpeed = Input.GetAxis("Horizontal");
        bool isTouched = Physics2D.OverlapPoint(gCheck.position, groundLayer);

        if (Input.GetKey(KeyCode.Space))
        {

            if (isTouched)
            {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
                isTouched = false;
            }
        }
        

        rb.velocity = new Vector2(mSpeed * speed, rb.velocity.y);
    }
}