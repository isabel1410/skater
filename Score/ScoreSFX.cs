using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSFX : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    private EventInstance _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = RuntimeManager.CreateInstance("event:/EarnPoint");

        ScoreManager score = FindObjectOfType<ScoreManager>();
        score.PlaySFX.AddListener(PlayEarnPointSound);
    }
    private void PlayEarnPointSound()
    {
        _instance.start();
    }
}
