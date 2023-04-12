using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : Die
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Off-Track") || collision.CompareTag("Gear") && !_isDead)
        {
            _isDead = true;
            OnDie?.Invoke();

            _animator.SetTrigger("Fall Apart");

            Movement m = GetComponent<Movement>();
            Destroy(m);
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
