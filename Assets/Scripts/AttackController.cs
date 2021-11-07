using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;

    public void Attack()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        
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
