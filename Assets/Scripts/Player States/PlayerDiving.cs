using UnityEngine;

public class PlayerDiving : IState
{
    private Animator _animator;

    public PlayerDiving(Animator animator)
    {
        _animator = animator;
    }
    
    public void Tick() { }

    public void OnEnter()
    {
        _animator.SetTrigger("dive");
    }

    public void OnExit() { }
}
