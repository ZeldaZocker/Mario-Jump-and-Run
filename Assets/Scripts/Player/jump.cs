using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float jumpheight;
    public Rigidbody2D rb;
    public bool grounded;
    public bool doubleJump;
    public Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        grounded = true;
        doubleJump = true;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (grounded)
            anim.SetBool("isGrounded", true);
        else
            anim.SetBool("isGrounded", false);


        if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Player").GetComponent<PlayerMovement>().IsInputEnabled)
        {
            if (jumpheight != 0)
            {
                _Jump();
            }
            if (jumpheight == 0)
            {
                jumpheight = 2;
                _Jump();
            }
        }
    }



    void _Jump()
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
    
    public void JumpReset()
    {
        grounded = true;
        doubleJump = true;
    }


}
