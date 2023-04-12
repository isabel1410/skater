using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Input : MonoBehaviour
{
    private bool _accelerate;
    public bool Accelerate { get { return _accelerate; } }

    public UnityEvent ToggleSettings;

    public void OnAccelerate(InputValue value)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") return;
        _accelerate = value.isPressed;
    }

    public void OnToggleSettings(InputValue value)
    {
        ToggleSettings?.Invoke();
    }
}
