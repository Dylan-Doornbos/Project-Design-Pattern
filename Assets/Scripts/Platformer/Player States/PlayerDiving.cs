using UnityEngine;

public class PlayerDiving : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform _playerTransform;
    private float _diveForce;

    public PlayerDiving(Rigidbody2D rb, Animator animator, Transform playerTransform, float diveForce)
    {
        _rb = rb;
        _animator = animator;
        _playerTransform = playerTransform;
        _diveForce = diveForce;
    }
    
    public void Tick() { }

    public void OnEnter()
    {
        _animator.SetTrigger("dive");
        
        float velocityX = _diveForce;

        if (_playerTransform.localScale.x < 0)
        {
            velocityX = -velocityX;
        }

        Vector2 diveVelocity = new Vector2(velocityX, -_diveForce);
        _rb.velocity = diveVelocity;
    }

    public void OnExit() { }
}
