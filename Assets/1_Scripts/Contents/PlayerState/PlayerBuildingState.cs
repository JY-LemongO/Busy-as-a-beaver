using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingState : PlayerBaseState
{
    private float _delayTime = 3f;
    private float _timer = 0;

    public PlayerBuildingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        BuildDam();
        StartAnimation(_stateMachine.Player.AnimationData.BuildingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimationData.BuildingParameterHash);
    }

    public void BuildDam()
    {
        DamManager.Instance.Dam.BuildDam();
        PoolManager.Instance.Return(_stateMachine.Player.log);

        _stateMachine.Player._isMovingToDam = false;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        _timer += Time.deltaTime;

        if (_delayTime < _timer)
        {
            _timer = 0f;
            _stateMachine.Player.targetTree = null;
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
