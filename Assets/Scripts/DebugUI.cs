using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _currentStateTxt;
    [SerializeField] private Image _imageW;
    [SerializeField] private Image _imageA;
    [SerializeField] private Image _imageS;
    [SerializeField] private Image _imageD;
    [SerializeField] private Image _imageSpace;
    [SerializeField] private Image _imageShift;

    private List<keyImage> _keyImages;

    private Color _inactive = Color.grey;
    private Color _active = Color.white;
    
    private StateMachine _playerStateMachine;

    private void Awake()
    {
        _keyImages = new List<keyImage>()
        {
            new keyImage() {keyCode = KeyCode.W, image = _imageW},
            new keyImage() {keyCode = KeyCode.A, image = _imageA},
            new keyImage() {keyCode = KeyCode.S, image = _imageS},
            new keyImage() {keyCode = KeyCode.D, image = _imageD},
            new keyImage() {keyCode = KeyCode.Space, image = _imageSpace},
            new keyImage(){keyCode = KeyCode.LeftShift, image = _imageShift}
        };

        foreach (keyImage keyImage in _keyImages)
        {
            keyImage.image.color = _inactive;
        }
        
        _playerStateMachine = _player.playerStateMachine;
        _playerStateMachine.onStateChanged += updateStateTxt;
    }

    private void Update()
    {
        foreach (keyImage keyImage in _keyImages)
        {
            if (Input.GetKeyDown(keyImage.keyCode))
            {
                keyImage.image.color = _active;
            }
            else if (Input.GetKeyUp(keyImage.keyCode))
            {
                keyImage.image.color = _inactive;
            }
        }
    }

    private void updateStateTxt(IState state)
    {
        _currentStateTxt.text = state.GetType() + " state";
    }
}

public struct keyImage
{
    public KeyCode keyCode;
    public Image image;
}