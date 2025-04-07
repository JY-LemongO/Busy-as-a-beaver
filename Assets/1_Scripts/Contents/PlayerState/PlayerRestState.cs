using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestState : PlayerBaseState
{
    bool isRest;

    public PlayerRestState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(_stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(_stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        if (TryGetTargetTree())
        {
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
    }
}
