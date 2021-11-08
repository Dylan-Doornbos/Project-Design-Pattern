using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private Pool _originPool;

    public void ReturnToPool()
    {
        _originPool.AddToPool(this);
    }

    public void SetOriginPool(Pool pool)
    {
        _originPool = pool;
    }
}
