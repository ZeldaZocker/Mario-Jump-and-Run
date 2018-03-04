using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    public float jumpheight;
    public Rigidbody2D rb;
    public bool grounded;
    public bool doubleJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        grounded = true;
        doubleJump = true;
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpheight != 0)
            {
                Jump();
            }
            if (jumpheight == 0)
            {
                jumpheight = 2;
                Jump();
            }
        }
    }



    void Jump()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(0, jumpheight);
            //this.GetComponent<Rigidbody>().AddForce(Vector3.up * 20 * jumpheight);
            grounded = false;
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(0, jumpheight);
           // this.GetComponent<Rigidbody>().AddForce(Vector3.up * 20 * jumpheight);
            doubleJump = false;
        }
    }
    
    public void jumpReset()
    {
        grounded = true;
        doubleJump = true;
    }


}
