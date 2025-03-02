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
        Rotate();
        StartAnimation(_stateMachine.Player.AnimationData.InteracrtionParameterName);
    }

    public override void Exit()
    {
        base.Exit();
        _stateMachine.Player.isInteraction = false;
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

    private void Rotate()
    {
        if (_stateMachine.Player.targetTree != null)
        {
            Transform targetTransform = _stateMachine.Player.targetTree.gameObject.transform;
            Transform playerTransform = _stateMachine.Player.transform;
            var look = targetTransform.position - playerTransform.position;
            look.y = 0;

            var targetRotation = Quaternion.LookRotation(look);
            _stateMachine.Player.transform.rotation = targetRotation;
        }
    }
}
