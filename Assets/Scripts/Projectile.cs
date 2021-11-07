using System;
using UnityEngine;

[RequireComponent(typeof(Poolable))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    private Rigidbody2D _rb;
    private Poolable _poolable;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _poolable = GetComponent<Poolable>();
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        _rb.velocity = moveDirection * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _poolable.ReturnToPool();
        gameObject.SetActive(false);
    }
}
