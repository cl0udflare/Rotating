using System.Collections;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _victory;
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _blur;
    [SerializeField] private TextMeshProUGUI _finishScores;
    [SerializeField] private ScoreDisplayer _scoreDisplayer;

    private void OnEnable()
    {
        _scoreDisplayer.SetScore(_finishScores);
        _blur.SetActive(true);
    }
    private void Update()
    {
        if (!_blur.activeSelf) return;
        
        StartCoroutine(View(0.4f, _victory));
        StartCoroutine(View(0.5f, _finishScores.gameObject));
        StartCoroutine(View(0.6f, _button));
    }

    private IEnumerator View(float timeInSec, GameObject gameObjects)
    {
        yield return new WaitForSeconds(timeInSec);
        
        if (gameObjects.transform.localScale != Vector3.one)
            gameObjects.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
    }
}
