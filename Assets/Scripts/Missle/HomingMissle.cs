using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;



[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    public GameObject explosion;
    public Transform target;
    private Rigidbody2D rb;
    public ObscuredFloat speed;
    public ObscuredFloat rotateSpeed = 200.0f;
    public ObscuredFloat startTime;
    public ObscuredFloat existTime;
    public ObscuredFloat radius = 30.0f;
    public ObscuredInt damage = 1;
    public int destroyedMissles = 0;


    void Start()
    {
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


    void FixedUpdate()
    {

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
        if (col.gameObject.CompareTag("Player"))
        {
            //Send the damage taken event to the CharacterStats
            var effect = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(effect.gameObject, 2f);
            if (col.GetComponent<CharacterStats>().isInvulnerable == false)
            {
                Debug.Log("Hitted");
                col.GetComponent<CharacterStats>().TakenDamage(damage);
            }

            //Search for near missles and destory them
            Collider2D[] nearMissles = Physics2D.OverlapCircleAll(col.GetComponent<Transform>().position, radius);
            //Debug.Log(nearMissles.Length);
            destroyedMissles = 0;
            foreach (Collider2D collider in nearMissles)
            {
                if (collider.tag == "Missle")
                {
                    Destroy(collider.gameObject);
                    ++destroyedMissles;
                }
            }
            //How many Missles got destroyed
            //Debug.Log("Destroyed: " + destroyedMissles);
        }
    }
}
