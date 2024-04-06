using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    private float cooldownTimer = Mathf.Infinity;

    [Header ("Collider Parameters")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    //[SerializeField] private int lifeTotal = 20;
    //[SerializeField] private int enemySpeed = 20;
    private Rigidbody2D sb;
    private Animator sAnim;
    private SpriteRenderer sparSprite;
    private Health_Death playerHealth;
    private Enemy_Patrol enemyPatrol;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = GetComponent<Rigidbody2D>();
        sAnim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Enemy_Patrol>();
        sparSprite = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                sAnim.SetTrigger("smol");
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

        //FacingRight();

        //sb.velocity = transform.right * enemySpeed;
        /*
        if (facingRight)
        {
            sparSprite.flipX = false;
        }
        else
        {
            sparSprite.flipX = true;
        }
        */

        if (isGrounded())
        {
            sAnim.SetBool("isGrounded", true);
        } 
        else
        {
            sAnim.SetBool("isGrounded", false);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        
        /*
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health_Death>();
        */
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
    }

    /*
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
    */

    /*
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
    */
}
