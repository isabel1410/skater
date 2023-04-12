using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private GameObject _finishedPopup;
    [SerializeField] private Text _scoreText;

    private ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        _finish.OnFinish.AddListener(ShowFinishedUI);
    }
    
    private void ShowFinishedUI()
    {
        _scoreText.text = "Your score: " + score.Score;
        _finishedPopup.SetActive(true);
    }
}
