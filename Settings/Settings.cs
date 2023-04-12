using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("UI-elements")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [Header("Settings")]
    [SerializeField] private GameSettings _gameSettings;
    private AudioSettings _audioSettings;

    private void Awake()
    {
        _audioSettings = GetComponent<AudioSettings>();
    }

    void Start()
    {
        _gameSettings.Load();

        _musicSlider.value = _gameSettings.MusicVolume;
        _sfxSlider.value = _gameSettings.SfxVolume;

        _audioSettings.ChangeMusicVolume(_gameSettings.MusicVolume);
        _audioSettings.ChangeSFXVolume(_gameSettings.SfxVolume);
    }

    public void SetMusicVolume(float value)
    {
        _gameSettings.MusicVolume = value;
    }

    public void SetSFXVolume(float value)
    {
        _gameSettings.SfxVolume = value;
    }


    public void Save()
    {
        Debug.Log("save");
        _gameSettings.Save();
    }
}
