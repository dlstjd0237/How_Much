using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    public PlayerIdleState(Entity owner, StateMachine stateMachine, string animationBoolName) : base(owner, stateMachine, animationBoolName)
    {
    }

  
}
