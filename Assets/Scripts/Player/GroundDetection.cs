using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat;
using CodeStage.AntiCheat.ObscuredTypes;

public class GroundDetection : MonoBehaviour
{


    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Jump jump;
    public Vector2 size = new Vector2(.6f, .2f);
    public ObscuredFloat angle = 0.0f;
    public ObscuredBool onGround;

    void Start()
    {
        jump = GameObject.Find("Player").GetComponent<Jump>();
        //Debug.Log("Ground Layer: " + LayerMask.NameToLayer("ground"));
        onGround = GameObject.Find("Player").GetComponent<Jump>().grounded;
        groundCheck = GetComponent<Transform>();
    }


    void FixedUpdate()
    {


        GameObject.Find("Player").GetComponent<Jump>().grounded = Physics2D.OverlapBox(groundCheck.position, size, angle, whatIsGround);

        if (GameObject.Find("Player").GetComponent<Jump>().grounded == false && (onGround != GameObject.Find("Player").GetComponent<Jump>().grounded))
        {
            //Debug.Log(GameObject.Find("Player").GetComponent<jump>().grounded);
            onGround = GameObject.Find("Player").GetComponent<Jump>().grounded;
        }

        if (GameObject.Find("Player").GetComponent<Jump>().grounded && (onGround != GameObject.Find("Player").GetComponent<Jump>().grounded))
        {
            //Debug.Log(GameObject.Find("Player").GetComponent<jump>().grounded);
            onGround = GameObject.Find("Player").GetComponent<Jump>().grounded;
            jump.JumpReset();
        }
    }
}
