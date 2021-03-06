using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class PlayerMovement : MonoBehaviour
{

    //Variables
    private Transform myTransform;
    public ObscuredFloat speed = 12f;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Vector2 move;
    private float moveHorizontal;
    public Transform trans;
    public bool spawned = false;
    public Vector2 spawn;
    public bool IsInputEnabled = true;
    public bool isDeath = false;
    private float dPosX;
    private float dPosY;
    private float dPosZ;
    private Animator anim;



    //Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    //Update
    void Update()
    {
        MovementUpdate();
        SetSpawn();
        SetAnim();
        CheckForDeath();

        if (Input.GetButton("Cancel") && IsInputEnabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    //Fixed Update
    void FixedUpdate()
    {
        MovementFixedUpdate();
    }


    private void MovementUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && IsInputEnabled)
            Time.timeScale += 0.5f;
        if (Input.GetKeyDown(KeyCode.KeypadMinus) && IsInputEnabled)
            Time.timeScale -= 0.5f;

        if (Input.GetAxis("Horizontal") > 0 && !facingRight && IsInputEnabled)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Input.GetAxis("Horizontal") < 0 && facingRight && IsInputEnabled)
            // ... flip the player.
            Flip();
    }

    private void MovementFixedUpdate()
    {
        if (IsInputEnabled)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 move = new Vector2(moveHorizontal * speed, rb.velocity.y);
            rb.velocity = move;
        }
    }


    private void SetSpawn()
    {
        if (spawned == false && GameObject.FindWithTag("PlayerSpawn").GetComponent<Transform>() != null)
        {
            GetComponent<Transform>().position = GameObject.FindWithTag("PlayerSpawn").GetComponent<Transform>().position;
            spawn = (Vector2)GameObject.FindWithTag("PlayerSpawn").GetComponent<Transform>().position;
            spawned = true;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void SetAnim()
    {
        if (rb.velocity.x != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }

    private void CheckForDeath()
    {
        if (isDeath)
            transform.position = new Vector3(dPosX, dPosY, dPosZ);
    }

    public void Respawn()
    {
        transform.position = spawn;
    }


    public void Death()
    {
        this.gameObject.GetComponent<CharacterStats>().isInvulnerable = true;
        this.gameObject.GetComponent<Renderer>().enabled = false;
        transform.localPosition.Set(0, 0, 0);
        IsInputEnabled = false;
        foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = false;
        }
        foreach (CircleCollider2D c in GetComponents<CircleCollider2D>())
        {
            c.enabled = false;
        }
        foreach (EdgeCollider2D c in GetComponents<EdgeCollider2D>())
        {
            c.enabled = false;
        }
        isDeath = true;
        dPosX = transform.position.x;
        dPosY = transform.position.y;
        dPosZ = transform.position.z;
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
