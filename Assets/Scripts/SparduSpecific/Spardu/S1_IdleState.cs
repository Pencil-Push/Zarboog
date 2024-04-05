using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_IdleState : IdleState
{
    private Spardu01 enemy;
   public S1_IdleState(Entity entity, Finite_State_Machine stateMach, string animBoolName, D_IdleState stateData, Spardu01 enemy) : base(entity, stateMach, animBoolName, stateData)
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

        if(isIdleTimeOver)
        {
            stateMach.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        
    }
}
