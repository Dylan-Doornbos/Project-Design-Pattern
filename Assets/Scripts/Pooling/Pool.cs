using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Pool : ScriptableObject
{
    [SerializeField] private Poolable _defaultObject;
    private Queue<Poolable> _pool = new Queue<Poolable>();

    public void AddToPool(Poolable poolable)
    {
        _pool.Enqueue(poolable);
    }

    public Poolable GetObject()
    {
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();
        }

        Poolable poolable = Instantiate(_defaultObject);
        poolable.SetPool(this);

        return poolable;
    }
}
