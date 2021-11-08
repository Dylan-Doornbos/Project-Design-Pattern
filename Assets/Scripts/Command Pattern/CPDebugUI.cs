using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPDebugUI : MonoBehaviour
{
    [SerializeField] private Text _txtTimeStamp;
    [SerializeField] private Image _imageR;
    [SerializeField] private Image _imageShift;
    private List<keyImage> _keyImages;

    private void Start()
    {
        _keyImages = new List<keyImage>()
        {
            new keyImage() {image = _imageR, keyCode = KeyCode.R},
            new keyImage() {image = _imageShift, keyCode = KeyCode.LeftShift}
        };

        foreach (keyImage keyImage in _keyImages)
        {
            keyImage.image.color = Color.grey;
        }
    }

    private void Update()
    {
        _txtTimeStamp.text = "Time stamp : " + TimelineManager.instance.timeStamp.ToString("F1");

        foreach (keyImage keyImage in _keyImages)
        {
            if (Input.GetKeyDown(keyImage.keyCode))
            {
                keyImage.image.color = Color.white;
            }
            else if (Input.GetKeyUp(keyImage.keyCode))
            {
                keyImage.image.color = Color.grey;
            }
        }
    }
}
