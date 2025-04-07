using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        ResetTarget();
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
        base.Update();

        if (!_stateMachine.Player.log.activeSelf)
        {
            if (!TryGetTargetTree())
            {
                _stateMachine.Player.target = _stateMachine.Player.house.gameObject;
                _stateMachine.ChangeState(_stateMachine.WalkState);
            }
            else
                _stateMachine.ChangeState(_stateMachine.WalkState);
        }
        else if (_stateMachine.Player.log.activeSelf)
        {
            _stateMachine.Player.target = _stateMachine.Player.scanner.Scan("Dam").gameObject;
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
    }

}
