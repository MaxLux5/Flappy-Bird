using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private int _score;
    private Text _scoreText;

    public Action increaseScore;

    private void Awake()
    {
        increaseScore += OnScoreIncrease;
        _scoreText = GetComponent<Text>();
    }

    private void OnScoreIncrease()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
