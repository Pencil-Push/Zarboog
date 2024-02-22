using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // There are two standard methods to move the player. One in Transform.
    // Translate and the other is Rigidbody.velocity. Using Transform.Translate
    // Will not activate any collisions. So you want to use Rigidbody.velocity for
    // physics based purposes.
    
    public float speed;
    public LayerMask groundLayer;
    Rigidbody2D rb;
    // private Animator anim;
    private BoxCollider2D boxCollider;
    bool m_FacingRight;

    Vector2 movement;
    

    void Start()
    {
        // Grab references for rigidbody from object at start
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        m_FacingRight = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Jump Method; checking for Space key
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        if (!m_FacingRight && horizontalInput > 0)
        {
           Flip();
        }
        else if (m_FacingRight && horizontalInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
       
       m_FacingRight = !m_FacingRight;
       transform.Rotate(0f, 180f, 0f);
    }

    // Jump Method; RaycastHit2D & BoxCollider2D
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    // private bool onWall() "Wall Jump"

    // Checks the player for when they are able to attack
    
}
