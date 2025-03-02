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
        if (_stateMachine.Player.targetTree != null)
            return;

        if (TryGetTarget())
        {
            MoveToTarget();
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
    }

    public virtual void Update()
    {
        if (ReachTheTarget())
        {
            Interaction();
            _stateMachine.ChangeState(_stateMachine.InteractionState);
            Debug.Log($"[PlayerBaseState] 스테이트 전환  :: {_stateMachine.InteractionState.ToString()}");
        }
    }

    public bool TryGetTarget()
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

    public void MoveToTarget()
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

    public void Interaction()
    {
        _stateMachine.Player.isInteraction = true;
    }

    protected void StartAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
