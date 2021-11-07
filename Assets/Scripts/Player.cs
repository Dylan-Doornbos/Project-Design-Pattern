using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _diveForce;

    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Collider2D _groundedChecker;

    private Rigidbody2D _rb;
    private Animator _animator;

    private StateMachine _playerStateMachine = new StateMachine();
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        PlayerGrounded playerGrounded = new PlayerGrounded(_rb, _animator, transform, _moveSpeed, _jumpForce);
        PlayerAirborne playerAirborne = new PlayerAirborne(_rb, _animator, transform, _diveForce);

        _playerStateMachine.AddTransition(playerGrounded, playerAirborne, isAirborne());
        _playerStateMachine.AddTransition(playerAirborne, playerGrounded, isGrounded());

        Func<bool> isAirborne() => () => _groundedChecker.IsTouchingLayers(_groundLayers) == false;
        Func<bool> isGrounded() => () => _groundedChecker.IsTouchingLayers(_groundLayers);

        _playerStateMachine.SetState(playerGrounded);
    }

    private void Update()
    {
        _playerStateMachine.Tick();
    }
}
