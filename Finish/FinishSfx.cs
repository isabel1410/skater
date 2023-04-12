using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSfx : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    private EventInstance _instance;

    private Finish _finish;
    private bool _played;

    // Start is called before the first frame update
    void Start()
    {
        _instance = RuntimeManager.CreateInstance("event:/Finish");

        _finish = FindObjectOfType<Finish>();
        _finish.OnFinish.AddListener(PlayFinishSound);
    }

    private void PlayFinishSound()
    {
        if (!_played)
        {
            _instance.start();
            _played = true;
        }
    }
}
