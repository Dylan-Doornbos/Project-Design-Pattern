using UnityEngine;

public class PlayerAirborne : IState
{
    public bool hasDived { get; private set; }
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform _playerTransform;
    private float _diveForce;

    public PlayerAirborne(Rigidbody2D rb, Animator animator, Transform playerTransform, float diveForce)
    {
        _rb = rb;
        _animator = animator;
        _playerTransform = playerTransform;
        _diveForce = diveForce;
    }

    public void Tick()
    {
        if (!hasDived && Input.GetKeyDown(KeyCode.Space))
        {
            float velocityX = _diveForce;

            if (_playerTransform.localScale.x < 0)
            {
                velocityX = -velocityX;
            }

            Vector2 diveVelocity = new Vector2(velocityX, -_diveForce);
            _rb.velocity = diveVelocity;
            
            _animator.SetTrigger("dive");
            hasDived = true;
        }
    }

    public void OnEnter()
    {
        hasDived = false;
        _animator.SetBool("isGrounded", false);
        _animator.SetTrigger("jump");
    }

    public void OnExit()
    {
    }
}