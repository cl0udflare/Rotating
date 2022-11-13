using TMPro;
using UnityEngine;

public class MultiplicatorDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _XCounter;
    [SerializeField] private TextMeshProUGUI _scoresX;
    [SerializeField] private ScoreManager _scoreManager;

    private void Update()
    {
        if (_scoreManager.Multiplicator > 1)
        {
            if (_XCounter.transform.position.x < 710)
                _XCounter.transform.position += new Vector3(480 * Time.deltaTime, 0, 0);
            
            _scoresX.text = "x" + _scoreManager.Multiplicator;
        }
        else
        {
            if (_XCounter.transform.position.x > 520)
                _XCounter.transform.position -= new Vector3(480 * Time.deltaTime, 0, 0);
        }
    }
}