using UnityEngine;

public class PlayerGrounded : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _moveSpeed;
    private float _jumpForce;

    public PlayerGrounded(Rigidbody2D rb, Animator animator, SpriteRenderer spriteRenderer, float moveSpeed, float jumpForce)
    {
        _rb = rb;
        _animator = animator;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
        _spriteRenderer = spriteRenderer;
    }
    
    public void Tick()
    {
        handleMovement();

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
            _spriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        
        _animator.SetFloat("moveSpeed", Mathf.Abs(moveDirection.x));

        Vector2 movement = moveDirection.normalized * Time.deltaTime * _moveSpeed;
        movement.y = _rb.velocity.y;

        _rb.velocity = movement;
    }

    public void OnEnter()
    {
        _animator.SetBool("isGrounded", true);
    }

    public void OnExit() { }
}
