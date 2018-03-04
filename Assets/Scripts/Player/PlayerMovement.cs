using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Transform myTransform;
    public float speed = 15f;
    private Rigidbody2D rb;
    private bool facingRight = true;
    Vector2 move;
    float moveHorizontal;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Input.GetAxis("Horizontal") < 0 && facingRight)
            // ... flip the player.
            Flip();

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


        void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = move;
        //Debug.Log("moveHorizontal:" + moveHorizontal);
        //Debug.Log("rb.velocity:" + rb.velocity);
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

    public void Respawn ()
    {
        transform.position = new Vector3(-2.5f, 3.3f, 0f);
    }
    

}