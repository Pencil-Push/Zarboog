using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_MoveState : MoveState
{
    private Spardu01 enemy;
    public S1_MoveState(Entity entity, Finite_State_Machine stateMach, string animBoolName, D_MoveState stateData, Spardu01 enemy) : base(entity, stateMach, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMach.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        
    }
}
