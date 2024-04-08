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
    //private float attackTimer;
    private float cooldownTimer = Mathf.Infinity;

    [Header ("Ranged Attack")]
    [SerializeField] private Transform emitter;
    [SerializeField] private GameObject sProjectile;

    [Header ("Collider Parameters")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    private Rigidbody2D sb;
    private Animator sAnim;
    private SpriteRenderer sparSprite;
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
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                RangedAttack();
                sAnim.SetTrigger("smol");
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

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
        Instantiate(sProjectile, emitter.position, Quaternion.identity);
    }
}
