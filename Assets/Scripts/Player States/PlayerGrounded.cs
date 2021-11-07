using UnityEngine;

public class PlayerGrounded : IState
{
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private float _jumpForce;

    public PlayerGrounded(Rigidbody2D rb, float moveSpeed, float jumpForce)
    {
        _rb = rb;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
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

        Vector2 movement = moveDirection.normalized * Time.deltaTime * _moveSpeed;
        movement.y = _rb.velocity.y;

        _rb.velocity = movement;
    }

    public void OnEnter()
    { }

    public void OnExit() { }
}
