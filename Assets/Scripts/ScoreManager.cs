using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreDisplayer _scoreDisplayer;
    [SerializeField] private Player _player;
    [SerializeField] private AddScores _addScoresPrefab;
    
    [NonSerialized] public int Multiplicator = 1;
    private int _score;

    private void OnEnable()
    {
        _player.NeedAddScore += AddScore;
    }

    private void AddScore(int amount)
    {
        var addScores = Instantiate(_addScoresPrefab, _scoreDisplayer.transform, false);
        switch (amount)
        {
            case 1:
                addScores.Init(amount);
                addScores.SetFontSize(48f);
                addScores.SetFontStyle(FontStyles.Normal);
                break;
            case 5 or 10 :
                addScores.Init(amount);
                addScores.SetFontSize(54f);
                addScores.SetFontStyle(FontStyles.Bold);
                break;
            case 300:
                addScores.Init(amount);
                addScores.SetFontSize(66f);
                addScores.SetFontStyle(FontStyles.Bold);
                break;
        }
        
        addScores.SetScore(amount * Multiplicator);
        _score += amount * Multiplicator;
        _scoreDisplayer.UpdateScore(_score);
    }

    private void RemoveScore(int amount)
    {
        _score -= amount;
        _scoreDisplayer.UpdateScore(_score);
    }
}
