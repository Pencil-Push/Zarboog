using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finite_State_Machine
{
    //Keeps track of what state the enemy is currently in.
    //Won't be attached to any gameObject.

    // Start is called before the first frame update
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
