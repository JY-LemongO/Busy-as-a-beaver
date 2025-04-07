using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Services.Analytics.Internal;
using Unity.VisualScripting;
using UnityEngine;
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

    }

    public virtual void Update()
    {
    }

    public bool TryGetTargetTree()
    {
        if (TreeManager.Instance.GetClosestTree(_stateMachine.Player.transform) != null)
            _stateMachine.Player.target = TreeManager.Instance.GetClosestTree(_stateMachine.Player.transform).gameObject;
        else
            _stateMachine.Player.target = null;

        if (_stateMachine.Player.target != null)
        {
            _stateMachine.Player.target.GetComponent<Resource_Tree>().SetBeaver(_stateMachine.Player as Beaver);
            _stateMachine.Player.target.GetComponent<Resource_Tree>().OnTreeDestroyed += OnGetLog;
            return true;
        }
        return false;
    }

    public bool ReachTheTarget(string targetLayerName)
    {
        int targetLayer = LayerMask.NameToLayer(targetLayerName);

        Ray ray = new Ray(_stateMachine.Player.transform.position + Vector3.up * 0.5f, _stateMachine.Player.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1f, 1 << targetLayer, QueryTriggerInteraction.Collide))
        {
            if (hit.collider.gameObject.layer == targetLayer)
            {
                return true;
            }
        }
        return false;
    }
    
    public void ResetTarget()
    {
        _stateMachine.Player.target = null;
        _stateMachine.Player.unit.target = null;
    }

    #region GJY
    private void OnGetLog()
    {
        _stateMachine.Player.target.GetComponent<Resource_Tree>().OnTreeDestroyed -= OnGetLog;

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
