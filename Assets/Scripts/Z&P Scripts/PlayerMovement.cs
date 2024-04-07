using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // There are two standard methods to move the player. One in Transform.
    // Translate and the other is Rigidbody.velocity. Using Transform.Translate
    // Will not activate any collisions. So you want to use Rigidbody.velocity for
    // physics based purposes.
    
    [Header ("Player Parameters")] 
    [SerializeField] private float speed;
    public LayerMask groundLayer;
    private bool facingRight = true;
    [SerializeField] private Transform firePoint;
    Vector2 movement;

    [Header ("Player Components")]
    Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Animator zAnimator;
    private SpriteRenderer zSprite;
    [SerializeField] private TrailRenderer zTrail;

    [Header ("Wall Parameters")]
    private bool isTouchingFront;
    [SerializeField] private Transform wallCheck;
    private bool wallSliding;
    [SerializeField] private float wallSlideSpeed;
    private bool wallJump;
    [SerializeField] private float xWallForce;
    [SerializeField] private float yWallForce;
    [SerializeField] private float wallJumpTime;

    [Header ("Dash Parameters")]
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    

    void Start()
    {
        // Grab references for rigidbody from object at start
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        zAnimator = GetComponent<Animator>();
        zSprite = GetComponent<SpriteRenderer>();
        zTrail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        // Calls the Check for char position
        FacingRight();

        if (isDashing)
        {
            return;
        }

        // movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        zAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Flip Wall Check child object
        if (facingRight)
        {
            wallCheck.transform.position = transform.position + new Vector3(.48f, 0, 0);
        }
        else
        {
            wallCheck.transform.position = transform.position + new Vector3(-.48f, 0, 0);
        }

        if (facingRight)
        {
            firePoint.transform.position = transform.position + new Vector3(1.4f, 0, 0);
        }
        else
        {
            firePoint.transform.position = transform.position + new Vector3(-1.4f, 0, 0);
        }
        
        // Jump Method; checking for X key
        if (Input.GetKeyDown(KeyCode.X) && isGrounded())
        {
            Jump();
            zAnimator.ResetTrigger("Jump");
            zAnimator.SetTrigger("Jump");
        }
        
        // grounded anim param
        if (isGrounded())
        {
            zAnimator.SetBool("isGrounded", true);
        }
        else
        {
            zAnimator.SetBool("isGrounded", false);
        }

        // Wall jump shit
        isTouchingFront = Physics2D.OverlapCircle(wallCheck.position, 0.5f, groundLayer);

        if (isTouchingFront == true && !isGrounded() && horizontalInput != 0)
        {
            wallSliding = true;
            zAnimator.SetBool("isWalled", true);
        }
        else
        {
            wallSliding = false;
            zAnimator.SetBool("isWalled", false);
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.X) && wallSliding == true)
        {
            wallJump = true;
            Invoke("SetWallJumpFalse", wallJumpTime);
        }

        if (wallJump == true)
        {
            rb.velocity = new Vector2(xWallForce * -horizontalInput, yWallForce);
        }

        if (facingRight)
        {
            zSprite.flipX = false;
        }
        else
        {
            zSprite.flipX = true;
        }

        // Dash Shit
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && isGrounded())
        {
            StartCoroutine(Dash());
            zAnimator.SetTrigger("Dash");
        }
        else
        {
            StopCoroutine(Dash());
        }   
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }
    
    void SetWallJumpFalse()
    {
        wallJump = false;
    }

    private void FacingRight()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            facingRight = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            facingRight = false;
        }
    }

    // Jump Method; RaycastHit2D & BoxCollider2D
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }
    
    // Dash Couroutine
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x * dashPower, 0f);
        zTrail.emitting = true;
        yield return new WaitForSeconds(dashTime);
        zTrail.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    //

}
