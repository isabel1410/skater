using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent OnCollectCoin;

    private bool _taken;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_taken)
        {
            _taken = true;
            OnCollectCoin?.Invoke();
            Destroy(gameObject);
        }
    }
}
