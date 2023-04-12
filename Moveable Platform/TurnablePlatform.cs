using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnablePlatform : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _animator.SetTrigger("Turn");
        }
    }
}
