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
        StartAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterHash);
        _stateMachine.Player.targetTree.LogTree();
    }

    public override void Exit()
    {
        base.Exit();
        _stateMachine.Player.isInteraction = false;
        StopAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {

    }
}
