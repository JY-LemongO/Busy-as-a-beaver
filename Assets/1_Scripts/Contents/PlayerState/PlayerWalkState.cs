using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _stateMachine.Player.unit.SetTarget(_stateMachine.Player.target.transform);
        StartAnimation(_stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(_stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        if (ReachTheTarget("Dam") && _stateMachine.Player.log.activeSelf && _stateMachine.Player.target.name.Contains("Dam"))
            _stateMachine.ChangeState(_stateMachine.BuildingState);
        if (ReachTheTarget("Resource") && !_stateMachine.Player.log.activeSelf && _stateMachine.Player.target.name.Contains("Tree"))
            _stateMachine.ChangeState(_stateMachine.InteractionState);
        if (_stateMachine.Player._isResting && _stateMachine.Player.target == _stateMachine.Player.house.gameObject)
        {
            _stateMachine.ChangeState(_stateMachine.RestState);
        }
    }
}
