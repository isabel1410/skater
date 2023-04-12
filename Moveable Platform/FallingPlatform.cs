using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(CFallDown());
        }
    }

    private IEnumerator CFallDown()
    {
        yield return new WaitForSeconds(1.5f);
        _animator.SetTrigger("Fall");
    }
}
