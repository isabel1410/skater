using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    private static EventInstance _eventInstance;
    private void Start()
    {
        _eventInstance = RuntimeManager.CreateInstance("event:/BackgroundMusic");
        _eventInstance.start();
        _eventInstance.release();
    }

    public void FadeBackgroundMusic()
    {
        _eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
