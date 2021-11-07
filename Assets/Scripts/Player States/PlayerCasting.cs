using UnityEngine;

public class PlayerCasting : IState
{
    private Rigidbody2D _rb;
    private Animator _animator;

    public PlayerCasting(Rigidbody2D rb, Animator animator)
    {
        _rb = rb;
        _animator = animator;
    }
    
    public void Tick() { }

    public void OnEnter()
    {
        _animator.SetTrigger("cast");
        _animator.SetBool("isCasting", true);
        _rb.velocity = Vector2.zero;
    }

    public void OnExit()
    {
        _animator.SetBool("isCasting", false);
    }
}
