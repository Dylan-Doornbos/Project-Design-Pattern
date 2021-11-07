using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();

    public event Action<IState> onStateChanged;

    private IState _currentState;

    public void Tick()
    {
        Transition transition = GetTransition();

        while (transition != null)
        {
            SetState(transition.targetState);
            transition = GetTransition();
        }
        
        _currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if (_currentState == state)
            return;

        _currentState?.OnExit();
        _currentState = state;
        onStateChanged?.Invoke(state);
        _currentState?.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> condition)
    {
        List<Transition> transitions;
        
        if(!_transitions.TryGetValue(from.GetType(), out transitions))
        {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }
        
        transitions.Add(new Transition(to, condition));
    }

    public Transition GetTransition()
    {
        List<Transition> transitions;

        if (_transitions.TryGetValue(_currentState.GetType(), out transitions))
        {        
            foreach (Transition transition in transitions)
            {
                if (transition.condition())
                {
                    return transition;
                }
            }
        }

        return null;
    }
}
