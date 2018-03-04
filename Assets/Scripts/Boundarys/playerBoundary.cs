using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBoundary : MonoBehaviour {


    public Transform tf;
    public Vector3 offset;

    void Start () {
		
	}
	
	void LateUpdate () {
        transform.position = new Vector3(tf.position.x, -10, 0);

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
