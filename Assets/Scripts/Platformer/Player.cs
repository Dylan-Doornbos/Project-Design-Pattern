using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _diveForce;
    [SerializeField] private float _inAirMoveForce;

    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Collider2D _groundedChecker;

    private Rigidbody2D _rb;
    private Animator _animator;

    public StateMachine playerStateMachine { get; } = new StateMachine();
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //Create states
        PlayerGrounded playerGrounded = new PlayerGrounded(_rb, _animator, transform, _moveSpeed, _jumpForce);
        PlayerAirborne playerAirborne = new PlayerAirborne(_rb, _animator, transform, _inAirMoveForce, _moveSpeed);
        PlayerCasting playerCasting = new PlayerCasting(_rb, _animator);
        PlayerDiving playerDiving = new PlayerDiving(_rb, _animator, transform, _diveForce);

        //Create transitions between states
        playerStateMachine.AddTransition(playerGrounded, playerAirborne, isAirborne());
        playerStateMachine.AddTransition(playerGrounded, playerCasting, startCasting());
        playerStateMachine.AddTransition(playerAirborne, playerGrounded, isGrounded());
        playerStateMachine.AddTransition(playerAirborne, playerDiving, startDiving());
        playerStateMachine.AddTransition(playerDiving, playerGrounded, isGrounded());
        
        playerStateMachine.AddTransition(playerCasting, playerGrounded, stopCasting());
        Func<bool> stopCasting() => () => Input.GetKeyUp(KeyCode.LeftShift);

        //Conditions for the transitions
        Func<bool> isGrounded() => () => _groundedChecker.IsTouchingLayers(_groundLayers);
        Func<bool> isAirborne() => () => _groundedChecker.IsTouchingLayers(_groundLayers) == false;
        Func<bool> startCasting() => () => Input.GetKey(KeyCode.LeftShift);
        Func<bool> startDiving() => () => Input.GetKeyDown(KeyCode.Space);

        playerStateMachine.SetState(playerGrounded);
    }

    private void Update()
    {
        playerStateMachine.Tick();
    }
}
