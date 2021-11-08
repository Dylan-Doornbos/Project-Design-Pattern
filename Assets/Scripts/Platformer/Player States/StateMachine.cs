using System;
using System.Collections.Generic;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();

    public event Action<IState> onStateChanged;


    public void Tick()
    {
        Transition transition = getValidTransition();

        //Transition to a different state if possible
        if (transition != null)
        {
            SetState(transition.targetState);
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

    private Transition getValidTransition()
    {
        List<Transition> transitionsFromCurrentState;

        //Get a list of transitions from the Dictionary that can occur from the current state
        if (_transitions.TryGetValue(_currentState.GetType(), out transitionsFromCurrentState))
        {
            //Return a transition that has their condition met
            foreach (Transition transition in transitionsFromCurrentState)
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
