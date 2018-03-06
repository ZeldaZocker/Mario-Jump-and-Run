using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{


    public LayerMask whatIsGround;
    public Transform groundCheck;
    public jump jump;
    public Vector2 size = new Vector2(.6f, .2f);
    public float angle = 0.0f;
    public bool onGround;

    void Start()
    {
        jump = GameObject.Find("Player").GetComponent<jump>();
        //Debug.Log("Ground Layer: " + LayerMask.NameToLayer("ground"));
        onGround = GameObject.Find("Player").GetComponent<jump>().grounded;
        groundCheck = GetComponent<Transform>();
    }


    void FixedUpdate()
    {


        GameObject.Find("Player").GetComponent<jump>().grounded = Physics2D.OverlapBox(groundCheck.position, size, angle, whatIsGround);

        if (GameObject.Find("Player").GetComponent<jump>().grounded == false && (onGround != GameObject.Find("Player").GetComponent<jump>().grounded))
        {
            //Debug.Log(GameObject.Find("Player").GetComponent<jump>().grounded);
            onGround = GameObject.Find("Player").GetComponent<jump>().grounded;
        }

        if (GameObject.Find("Player").GetComponent<jump>().grounded && (onGround != GameObject.Find("Player").GetComponent<jump>().grounded))
        {
            //Debug.Log(GameObject.Find("Player").GetComponent<jump>().grounded);
            onGround = GameObject.Find("Player").GetComponent<jump>().grounded;
            jump.jumpReset();
        }
    }
}