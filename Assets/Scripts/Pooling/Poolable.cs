using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private Pool _pool;

    public void ReturnToPool()
    {
        _pool.AddToPool(this);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
