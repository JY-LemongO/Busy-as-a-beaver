using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionState : PlayerBaseState
{
    public PlayerInteractionState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterName);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterName);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
