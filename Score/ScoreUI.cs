using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _reasoningText;

    private CanvasGroup _canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = _reasoningText.GetComponent<CanvasGroup>();
        ScoreManager score = FindObjectOfType<ScoreManager>();

        score.UpdateScoreUI.AddListener(UpdateScoreUI);
        score.UpdateReasoning.AddListener(UpdateReasoningUI);

        UpdateScoreUI(score.Score);
        UpdateReasoningUI();
    }

    private void UpdateScoreUI(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void UpdateReasoningUI()
    {
        _reasoningText.text = null;
        _canvasGroup.alpha = 1f;
    }

    private void UpdateReasoningUI(string reason)
    {
        _reasoningText.text = reason;
        _canvasGroup.alpha = 1f;
        StartCoroutine(CoroFadeMessage());
    }

    private IEnumerator CoroFadeMessage()
    {
        while (_canvasGroup.alpha != 0f)
        {
            _canvasGroup.alpha -= Time.deltaTime * 0.3f;
            yield return null;
        }
    }



}
