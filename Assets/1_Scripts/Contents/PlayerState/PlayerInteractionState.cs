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
        _stateMachine.Player.target.GetComponent<Resource_Tree>().LogTree();
        StartAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterHash);
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
        if (!_stateMachine.Player.target.GetComponent<Resource_Tree>().IsLogging)
        {
            _stateMachine.Player.log.SetActive(true);
            _stateMachine.Player._isMovingToDam = true;
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
