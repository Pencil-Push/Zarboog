using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    //Will have all functions each state should have; i.e. enter//exit functions, normal update function, and physics function.

    // Start is called before the first frame update
    protected Finite_State_Machine stateMach;
    protected Entity entity;

    protected float startTime;
    protected string animBoolName;

    public State(Entity entity, Finite_State_Machine stateMach, string animBoolName)
    {
        this.entity = entity;
        this.stateMach = stateMach;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

}
