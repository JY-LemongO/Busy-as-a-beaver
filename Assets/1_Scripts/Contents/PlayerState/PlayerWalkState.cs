using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

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
        if (ReachTheTarget())
        {
            if (_stateMachine.Player._isMovingToDam)
            {
                _stateMachine.ChangeState(_stateMachine.BuildingState);
            }
            else
            {
                _stateMachine.Player.isInteraction = true;
                _stateMachine.ChangeState(_stateMachine.InteractionState);
                Debug.Log($"[PlayeyWalkState] 스테이트 전환  :: {_stateMachine.InteractionState.ToString()}");
            }
        }


    }
}
