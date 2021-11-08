using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    
    [SerializeField] private Pool _projectilePool;
    
    public void Attack()
    {
        Poolable obj = _projectilePool.GetObject();
        obj.transform.position = _projectileSpawnPoint.position;
        obj.gameObject.SetActive(true);

        Projectile projectile = obj.GetComponent<Projectile>();

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
