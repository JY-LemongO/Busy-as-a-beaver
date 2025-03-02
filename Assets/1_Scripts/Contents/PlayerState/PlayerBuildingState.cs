using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingState : PlayerBaseState
{
    public PlayerBuildingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(_stateMachine.Player.AnimationData.BuildingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimationData.BuildingParameterHash);
    }

    public void BuildDam()
    {

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {

    }
}
