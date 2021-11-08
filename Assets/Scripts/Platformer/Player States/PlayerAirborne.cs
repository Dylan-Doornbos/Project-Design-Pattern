using UnityEngine;

public class PlayerAirborne : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform _playerTransform;
    private float _moveForce;
    private float _maxMoveSpeed;

    public PlayerAirborne(Rigidbody2D rb, Animator animator, Transform playerTransform,
        float moveForce, float maxMoveSpeed)
    {
        _rb = rb;
        _animator = animator;
        _playerTransform = playerTransform;
        _moveForce = moveForce;
        _maxMoveSpeed = maxMoveSpeed;
    }

    public void Tick()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        Vector2 movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");

        _rb.AddForce(movement * Time.fixedDeltaTime * _moveForce);

        float maxSpeed = _maxMoveSpeed * Time.fixedDeltaTime;
        float excessSpeed = Mathf.Abs(_rb.velocity.x) - maxSpeed;
        
        if (excessSpeed > 0)
        {
            if (_rb.velocity.x > 0)
            {
                _rb.AddForce(Vector2.left * excessSpeed, ForceMode2D.Impulse);
            }
            else
            {
                _rb.AddForce(Vector2.right * excessSpeed, ForceMode2D.Impulse);
            }
        }

        if (_rb.velocity.x < 0)
        {
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_rb.velocity.x > 0)
        {
            _playerTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnEnter()
    {
        _animator.SetBool("isGrounded", false);
        _animator.SetTrigger("jump");
    }

    public void OnExit()
    {
    }
}