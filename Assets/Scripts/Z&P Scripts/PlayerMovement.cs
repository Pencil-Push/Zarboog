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
    private BoxCollider2D boxCollider;
    public Animator zAnimator;

    bool m_FacingRight;
    bool diagUP;
    bool diagDOWN;
    bool up;
    bool down;

    Vector2 movement;
    

    void Start()
    {
        // Grab references for rigidbody from object at start
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        zAnimator = GetComponent<Animator>();

        m_FacingRight = true;
        /*
        diagUP = false;
        diagDOWN = false;
        up = false;
        down = false;
        */
    }

    void Update()
    {
        // Calls the Check for char position
        // Positioning();
        
        // movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        zAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

        // Jump Method; checking for X key
        if (Input.GetKey(KeyCode.X) && isGrounded())
        {
            Jump();
            zAnimator.ResetTrigger("Jump");
            zAnimator.SetTrigger("Jump");
        }
        
        if (isGrounded())
        {
            zAnimator.SetBool("isGrounded", true);
        }
        else
        {
            zAnimator.SetBool("isGrounded", false);
        }
            
        if (!m_FacingRight && horizontalInput > 0)
        {
           Flip();
        }
        else if (m_FacingRight && horizontalInput < 0)
        {
            Flip();
        }
    }
    /*
    void Positioning()
    {
        if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow) ^ (Input.GetKey(KeyCode.RightArrow))))
        {
            diagUP = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) ^ (Input.GetKey(KeyCode.RightArrow))))
        {
            diagDOWN = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            down = true;
        }
        else
        {
          diagUP = false;
          diagDOWN = false;
          up = false;
          down = false;
        }
    }
    */

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
       
       m_FacingRight = !m_FacingRight;
       transform.Rotate(0f, 180f, 0f);
    }

    // Jump Method; RaycastHit2D & BoxCollider2D
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    //

}
