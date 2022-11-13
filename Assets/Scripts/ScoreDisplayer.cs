using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
    public void SetScore(TextMeshProUGUI score)
    {
        score.text = _scoreText.text;
    }
}
