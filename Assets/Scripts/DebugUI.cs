using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _currentStateTxt;
    private StateMachine _playerStateMachine;

    private void Awake()
    {
        _playerStateMachine = _player.playerStateMachine;
        _playerStateMachine.onStateChanged += updateStateTxt;
    }

    private void updateStateTxt(IState state)
    {
        _currentStateTxt.text = state.GetType() + " state";
    }
}
