using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat;
using CodeStage.AntiCheat.ObscuredTypes;

public class playerBoundary : MonoBehaviour
{


    public Transform tf;
    public Vector2 spawn;

    void Start()
    {
        if (GameObject.FindWithTag("Player").GetComponent<Transform>() != null)
        {
            tf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<Transform>() != null && GameObject.Find("Player").GetComponent<PlayerMovement>().spawned == true)
        {
            spawn = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().spawn;
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(tf.position.x, spawn.y - 10);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Transform>().position = spawn;
            col.GetComponent<CharacterStats>().TakenDamage(1);
            //Debug.Log("Respawn");
        }
    }
}
