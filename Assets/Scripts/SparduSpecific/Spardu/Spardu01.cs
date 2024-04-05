using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spardu01 : Entity
{
    public S1_IdleState idleState { get; private set; }
    public S1_MoveState moveState { get; private set; }
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new S1_MoveState(this, stateMach, "move", moveStateData, this);
        idleState = new S1_IdleState(this, stateMach, "idle", idleStateData, this);

        stateMach.Initialize(moveState);
    }
    
}
