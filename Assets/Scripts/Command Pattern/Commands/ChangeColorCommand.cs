using UnityEngine;
using UnityEngine.UI;

public class ChangeColorCommand : Command
{
    private Image _image;
    private Color _newColor;
    private Color _oldColor;

    public ChangeColorCommand(Image image, Color newColor)
    {
        _image = image;
        _newColor = newColor;
    }

    //Store the current color and set the new one
    public override void Execute()
    {
        _oldColor = _image.color;
        _image.color = _newColor;
    }

    //Go back to the previous color
    public override void Undo()
    {
        _image.color = _oldColor;
    }
}
