using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private Bus SFX;
    FMOD.Studio.Bus Music;
    private void Awake()
    {
        SFX = RuntimeManager.GetBus("bus:/SFX");
        Music = RuntimeManager.GetBus("bus:/Music");
    }

    public void ChangeSFXVolume(float value)
    {
        SFX.setVolume(value);
    }

    public void ChangeMusicVolume(float value)
    {
        Music.setVolume(value);
    }
}
