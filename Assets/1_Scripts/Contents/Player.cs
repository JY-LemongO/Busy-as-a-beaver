using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    public PlayerAnimationData AnimationData { get; private set; } = new PlayerAnimationData();
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public NavMeshAgent Agent { get; private set; }

    [SerializeField] private float _needDistance;
    [SerializeField] private float _moveSpeed;

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
    private void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    private void OnEnable()
    {

    }

    private void SetComponents()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
    }
}
