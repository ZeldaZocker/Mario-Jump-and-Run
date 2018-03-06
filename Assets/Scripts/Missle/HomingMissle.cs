using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;



[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour {

    public Transform target;
    private Rigidbody2D rb;
    public ObscuredFloat speed;
    public ObscuredFloat rotateSpeed = 200.0f;
    public ObscuredFloat startTime;
    public ObscuredFloat existTime;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Awake()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        existTime = Time.time - startTime;
    }


    void FixedUpdate () {

        //Debug.Log("existTime:" + existTime);

        speed = 5.0f + (existTime / 10);

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        //explode code here

        //Debug.Log(col);

       /* if (col.gameObject.tag != "Player" && col.gameObject.tag != "Missle")
        {
            GameObject.Find("MissleLauncher").GetComponent<MissleLauncher>().missles--;
            GameObject.Destroy(gameObject, 0);
        }*/

        if (col.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
            GameObject[] missles = GameObject.FindGameObjectsWithTag("Missle");
            foreach (GameObject missle in missles)
                Destroy(missle);
            GameObject.Find("MissleCounter").GetComponent<MissleCounter>().missles = 0;
            col.gameObject.GetComponent<PlayerMovement>().Respawn();
        }
    }
}