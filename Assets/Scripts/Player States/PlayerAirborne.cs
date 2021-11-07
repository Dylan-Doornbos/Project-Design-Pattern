using UnityEngine;

public class PlayerAirborne : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _diveForce;

    public PlayerAirborne(Rigidbody2D rb, Animator animator, float diveForce)
    {
        _rb = rb;
        _animator = animator;
        _diveForce = diveForce;
    }
    
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 diveVelocity = new Vector2(0, -_diveForce);

            _rb.velocity = diveVelocity;
        }
    }

    public void OnEnter()
    {
        _animator.SetBool("isGrounded", false);
    }

    public void OnExit() { }
}
