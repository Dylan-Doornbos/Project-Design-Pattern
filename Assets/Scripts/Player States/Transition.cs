using System;

public class Transition
{
    public Func<bool> condition { get; }

    public IState targetState { get; }

    public Transition(IState targetState, Func<bool> condition)
    {
        this.condition = condition;
        this.targetState = targetState;
    }
}
