using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
	private static EventInstance _eventInstance;
	private static bool _musicPlaying;


	void Start()
	{
		if (!_musicPlaying)
        {
			DontDestroyOnLoad(gameObject);
			_eventInstance = RuntimeManager.CreateInstance("event:/Level1Music");
			_eventInstance.start();
			_musicPlaying = true;
		}
	}

    private void Update()
    {
		if (SceneManager.GetActiveScene().name == "MainMenu")
        {
			StopBackgroundMusic();
			Destroy(this.gameObject);
        }
	}

    private void StopBackgroundMusic()
	{
		_eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_musicPlaying = false;
	}
}
