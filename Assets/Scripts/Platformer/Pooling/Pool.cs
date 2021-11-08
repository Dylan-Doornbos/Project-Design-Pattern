using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Pool : ScriptableObject
{
    [SerializeField] private Poolable _defaultObject;
    private readonly Queue<Poolable> _pool = new Queue<Poolable>();

    public void AddToPool(Poolable obj)
    {
        _pool.Enqueue(obj);
    }

    public Poolable GetObject()
    {
        //Return an object from the pool
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();
        }

        //Instantiate a new object if the pool is empty
        Poolable obj = Instantiate(_defaultObject);
        obj.SetOriginPool(this);
        return obj;
    }
}
