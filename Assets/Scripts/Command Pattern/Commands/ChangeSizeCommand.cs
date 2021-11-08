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
    
    public override void Execute()
    {
        _oldSize = _transform.localScale;
        _transform.localScale = _newSize;
    }

    public override void Undo()
    {
        _transform.localScale = _oldSize;
    }
}
