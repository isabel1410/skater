using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPopup;
    [SerializeField] private Text _scoreText;

    private ScoreManager score;

    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
    }

    public void ShowGameOverUI()
    {
        _scoreText.text = "Your score: " + score.Score;
        _gameOverPopup.SetActive(true);
    }
}
