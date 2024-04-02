using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [Header ("Attack Parameters")]
    

    [Header ("Collider Parameters")]
    public LayerMask groundLayer;
    private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    //[SerializeField] private int lifeTotal = 20;
    [SerializeField] private int enemySpeed = 20;
    Rigidbody2D sb;
    SpriteRenderer sparSprite;
    private bool facingRight = true;

    [Header ("Patrol")]
    private GameObject wayPoint01;
    private GameObject wayPoint02;
    

    // Start is called before the first frame update
    void Start()
    {
        // Grab components
        sb = GetComponent<Rigidbody2D>();
        sparSprite = GetComponent<SpriteRenderer>();

        // Waypoint Start
        wayPoint01 = GameObject.FindWithTag("wayPoint01");
        wayPoint02 = GameObject.FindWithTag("wayPoint02");
    }

    // Update is called once per frame
    void Update()
    {
        FacingRight();
        sb.velocity = transform.right * enemySpeed;

        if (facingRight)
        {
            sparSprite.flipX = false;
        }
        else
        {
            sparSprite.flipX = true;
        } 
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
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

    //private GameObject FindClosestWP (GameObject[] wayPoint)
}
