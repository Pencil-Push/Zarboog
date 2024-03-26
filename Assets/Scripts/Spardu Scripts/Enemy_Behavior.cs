using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [Header ("Attack Parameters")]
    private Enemy_Patrol enemyPatrol;

    [Header ("Collider Parameters")]
    public LayerMask groundLayer;
    private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    //public int lifeTotal = 20;
    [SerializeField] float enemySpeed;
    Rigidbody2D sb;

    [Header ("Patrol")]
    [SerializeField] Transform[] Positions;
    Transform sparPos;
    int sparPosIndex;

    // Start is called before the first frame update
    void Start()
    {
        sb = GetComponent<Rigidbody2D>();
        sparPos = Positions[0];  
    }

    // Update is called once per frame
    void Update()
    {
        //SparduPatrol();   
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
/*
    void SparduPatrol()
    {
        if (transform.position == sparPos.position)
        {
            sparPosIndex++;
            if (sparPosIndex >= Positions.Length)
            {
                sparPosIndex = 0;
            }
            sparPos = Positions[sparPosIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(sparPos, enemySpeed * Time.deltaTime);
        }
    }
    */
}
