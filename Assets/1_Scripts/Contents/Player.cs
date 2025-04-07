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

    [field: Header("Component")]
    public Unit unit { get; private set; }
    public Scanner scanner { get; private set; }

    [SerializeField] private float _needDistance;

    public GameObject target;
    public bool isInteraction = false;
    
    public GameObject log;
    public BeaverHouse house;

    public bool _isMovingToDam = false;
    public bool _isLogging = false;
    public bool _isResting = true;

    //public override void SetHouse(GameObject obj)
    //    => this.house = obj.GetComponentInParent<BeaverHouse>();

    private void Awake()
    {
        AnimationData.Initialize();

        Animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        scanner = GetComponent<Scanner>();
        unit = GetComponent<Unit>();

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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Animator.SetBool("Swim", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == house.gameObject)
        {
            _isResting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == house.gameObject)
        {
            _isResting = false;
        }
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    private void OnEnable()
    {

    }

}


