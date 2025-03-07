using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : Beaver
{
    [field: Header("Animations")]
    public PlayerAnimationData AnimationData { get; private set; } = new PlayerAnimationData();
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public NavMeshAgent Agent { get; private set; }

    [SerializeField] private float _needDistance;
    [SerializeField] private float _moveSpeed => DataManager.Instance.fixMoveSpeed;

    public Resource_Tree targetTree;
    public bool isInteraction = false;

    #region GJY
    public GameObject log;
    public BeaverHouse house;

    public bool _isMovingToDam = false;
    public bool _isLogging = false;
    #endregion

    public override void SetHouse(BeaverHouse house)
        => this.house = house;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Animator.SetBool("Swim", true);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        while (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -0.7f, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(-33.0f, gameObject.transform.rotation.y, transform.rotation.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Animator.SetBool("Swim", false);
        }
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
