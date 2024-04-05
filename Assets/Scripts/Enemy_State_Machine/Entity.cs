using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //[Header ("Enemy Variables")]
    public int facingDirection { get; private set; }
    private Vector2 velocityWorkspace;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    //[Header ("Enemy Components")]
    public Rigidbody2D sb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject enemy { get; private set; }
    public Finite_State_Machine stateMach;
    public D_Entity entityData;
    //This will be the base class that all the Enemies will gain Inheritance from.
    //Inheritance will be the base functions that every enemy will have; such as, health, damage, movement, etc.

    // Start is called before the first frame update
    

    public virtual void Start()
    {
        facingDirection = 1;

        enemy = transform.Find("Spardu").gameObject;
        sb = enemy.GetComponent<Rigidbody2D>();
        anim = enemy.GetComponent<Animator>();
        
        stateMach = new Finite_State_Machine();
    }

    public virtual void Update()
    {
        stateMach.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMach.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, sb.velocity.y);
        sb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, enemy.transform.right, entityData.wallCheckDistance, entityData.Ground);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.Ground);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        enemy.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }
}
