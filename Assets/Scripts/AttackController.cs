using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Pool _projectilePool;
    [SerializeField] private Transform _projectileSpawnPoint;

    public void Attack()
    {
        Poolable poolable = _projectilePool.GetObject();
        poolable.transform.position = _projectileSpawnPoint.position;
        poolable.gameObject.SetActive(true);

        Projectile projectile = poolable.GetComponent<Projectile>();

        if (projectile != null)
        {
            Vector3 shootDirection = Vector3.right;

            if (transform.localScale.x < 0)
            {
                shootDirection = Vector3.left;
                projectile.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                projectile.transform.localScale = new Vector3(1, 1, 1);
            }
        
            projectile.SetMoveDirection(shootDirection);
        }
    }
}
