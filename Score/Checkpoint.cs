using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent OnCheckpointReached;
    private bool _taken;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_taken)
        {
            _taken = true;
            OnCheckpointReached?.Invoke();
        }
    }
}
