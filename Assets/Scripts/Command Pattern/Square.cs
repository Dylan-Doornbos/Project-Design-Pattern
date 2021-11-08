using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnClick()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RandomizeSize();
        }
        else
        {
            RandomizeColor();
        }
    }

    public void RandomizeSize()
    {
        if (TimelineManager.instance != null
            && !TimelineManager.instance.isRewinding)
        {
            Vector3 randomSize = Vector3.one * Random.Range(1f, 3f);

            ChangeSizeCommand sizeCommand = new ChangeSizeCommand(transform, randomSize);
            sizeCommand.Execute();
            
            TimelineManager.instance.AddCommand(sizeCommand);
        }
    }

    public void RandomizeColor()
    {
        if (TimelineManager.instance != null
            && !TimelineManager.instance.isRewinding)
        {
            ChangeColorCommand colorCommand = new ChangeColorCommand(_image, Random.ColorHSV());
            colorCommand.Execute();

            TimelineManager.instance.AddCommand(colorCommand);
        }
    }
}