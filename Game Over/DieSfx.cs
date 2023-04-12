using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSfx : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    private EventInstance _instance;

    private bool _played;

    // Start is called before the first frame update
    void Start()
    {
        _instance = RuntimeManager.CreateInstance("event:/Crash");
    }

    public void PlayCrashSound()
    {
        if (!_played)
        {
            _instance.start();
            _played = true;
        }
    }
}
