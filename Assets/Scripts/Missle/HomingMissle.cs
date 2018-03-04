using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour {

    public Transform target;
    private Rigidbody2D rb;
    public float speed;
    public float rotateSpeed = 200.0f;
    public float startTime;
    public float existTime;


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

        speed = 5.0f + (existTime / 20);

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

        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Missle")
        {
            GameObject.Find("MissleLauncher").GetComponent<MissleLauncher>().missles--;
            GameObject.Destroy(gameObject, 0);
        }

        else if (col.gameObject.tag == "Player")
        {
            GameObject.Find("MissleLauncher").GetComponent<MissleLauncher>().missles--;
            col.gameObject.GetComponent<PlayerMovement>().Respawn();
            GameObject.Destroy(gameObject, 0);
        }
    }
}