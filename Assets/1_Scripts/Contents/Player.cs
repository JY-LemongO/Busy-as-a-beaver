using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    public PlayerAnimationData AnimationData { get; private set; } = new PlayerAnimationData();
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();

        SetComponents();

        StateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    private void SetComponents()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }
}
