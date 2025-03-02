using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine _stateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _stateMachine = playerStateMachine;

    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void PhysicsUpdate()
    {
        if (_stateMachine.Player._isMovingToDam)
        {
            MoveToDam();
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }

        if (_stateMachine.Player.targetTree != null)
            return;
        
        if (TryGetTargetTree())
        {
            MoveToTargetTree();
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
    }

    public virtual void Update()
    {

    }

    public bool TryGetTargetTree()
    {
        _stateMachine.Player.targetTree = TreeManager.Instance.GetClosestTree(_stateMachine.Player.transform);

        if (_stateMachine.Player.targetTree != null)
        {
            _stateMachine.Player.targetTree.SetBeaver(_stateMachine.Player as Beaver);
            _stateMachine.Player.targetTree.OnTreeDestroyed += OnGetLog;
            return true;
        }
        return false;
    }

    public void MoveToTargetTree()
    {
        Transform targetTrensform = _stateMachine.Player.targetTree.gameObject.transform;
        _stateMachine.Player.Agent.SetDestination(targetTrensform.position);
    }

    public bool ReachTheTarget()
    {
        NavMeshAgent agent = _stateMachine.Player.Agent;
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                // 목적지에 도달함
                return true;
            }
        }
        return false;
    }

    public void MoveToDam()
    {
        _stateMachine.Player.Agent.SetDestination(DamManager.Instance.Dam.moveToDamPosition.transform.position);
    }

    #region GJY
    private void OnGetLog()
    {
        _stateMachine.Player.targetTree.OnTreeDestroyed -= OnGetLog;

        _stateMachine.Player.log = ResourceManager.Instance.Instantiate("Prefabs/Tree/Log", _stateMachine.Player.transform);
        _stateMachine.Player.log.transform.localPosition = Vector3.zero;
        _stateMachine.Player.log.transform.localRotation = Quaternion.identity;

        _stateMachine.Player._isMovingToDam = true;
        _stateMachine.Player._isLogging = false;        
    }
    #endregion

    protected void StartAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
