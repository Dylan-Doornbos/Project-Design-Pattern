using UnityEngine;

public class ChangeSizeCommand : Command
{
    private Transform _transform;
    private Vector3 _newSize;
    private Vector3 _oldSize;

    public ChangeSizeCommand(Transform transform, Vector3 newSize)
    {
        _transform = transform;
        _newSize = newSize;
    }
    
    //Store the current scale and set the new one
    public override void Execute()
    {
        _oldSize = _transform.localScale;
        _transform.localScale = _newSize;
    }

    //Go back to the previous scale
    public override void Undo()
    {
        _transform.localScale = _oldSize;
    }
}
