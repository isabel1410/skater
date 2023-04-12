using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    public int Score { get { return _score; } }

    private readonly int _addedScoreOnFlip = 1;
    private readonly int _addedScoreOnCollectingDiamond = 1;
    private readonly int _addedScoreOnReachingCheckpoint = 1;

    public UnityEvent<int> UpdateScoreUI;
    public UnityEvent<string> UpdateReasoning;
    public UnityEvent PlaySFX;

    // Start is called before the first frame update
    void Start()
    {
        Movement player = (Movement)FindObjectOfType<Movement>();
        player.OnFlip.AddListener(Flip);
    }

    private void Flip()
    {
        _score += _addedScoreOnFlip;
        UpdateScoreUI?.Invoke(_score);
        UpdateReasoning?.Invoke("Flip done! + " + _addedScoreOnFlip);
        PlaySFX?.Invoke();
    }

    public void CollectedCoin()
    {
        _score += _addedScoreOnCollectingDiamond;
        UpdateScoreUI?.Invoke(_score);
        UpdateReasoning?.Invoke("Collected coin! + " +_addedScoreOnCollectingDiamond);
        PlaySFX?.Invoke();
    }

    public void ReachCheckpoint()
    {
        _score += _addedScoreOnReachingCheckpoint;
        UpdateScoreUI?.Invoke(_score);
        UpdateReasoning?.Invoke("Checkpoint reached! + " + _addedScoreOnReachingCheckpoint);
        PlaySFX?.Invoke();
    }
}
