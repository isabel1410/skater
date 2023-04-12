using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpsideDown : Die
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isDead && (collision.gameObject.layer == 3))
        {
            _isDead = true;
            OnDie?.Invoke();

            _animator.SetTrigger("Fall Apart");

            Movement m = GetComponentInParent<Movement>();
            Destroy(m);
            Rigidbody2D rigidbody2D = GetComponentInParent<Rigidbody2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
