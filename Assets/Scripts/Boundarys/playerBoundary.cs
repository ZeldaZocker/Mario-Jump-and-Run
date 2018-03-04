using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBoundary : MonoBehaviour {


    public Transform tf;
    public Vector2 spawn;

    void Start () {
        if (GameObject.Find("Player").GetComponent<Transform>() != null)
        {
            tf = GameObject.Find("Player").GetComponent<Transform>();
        }
    }
    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Transform>() != null && GameObject.Find("Player").GetComponent<PlayerMovement>().spawned == true)
        {
            spawn = GameObject.Find("Player").GetComponent<PlayerMovement>().spawn;
        }
    }

    void LateUpdate () {
        transform.position = new Vector3(tf.position.x, spawn.y - 10);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().Respawn();
            Debug.Log("Respawn");
        }
    }
}
