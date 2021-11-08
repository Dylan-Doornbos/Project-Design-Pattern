using UnityEngine;

public class PlayerGrounded : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform _playerTransform;
    private float _moveSpeed;
    private float _jumpForce;

    public PlayerGrounded(Rigidbody2D rb, Animator animator, Transform playerTransform, float moveSpeed, float jumpForce)
    {
        _rb = rb;
        _animator = animator;
        _playerTransform = playerTransform;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
    }
    
    public void Tick()
    {
        handleMovement();
        handleJumping();
    }

    private void handleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void handleMovement()
    {
        Vector2 moveDirection = Vector2.zero;
        
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = 0;

        if (moveDirection.x < 0)
        {
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDirection.x > 0)
        {
            _playerTransform.localScale = new Vector3(1, 1, 1);
        }
        
        _animator.SetFloat("moveSpeed", Mathf.Abs(moveDirection.x));

        Vector2 movement = moveDirection.normalized * Time.fixedDeltaTime * _moveSpeed;
        movement.y = _rb.velocity.y;

        _rb.velocity = movement;
    }

    public void OnEnter()
    {
        _animator.SetBool("isGrounded", true);
    }

    public void OnExit() { }
}
