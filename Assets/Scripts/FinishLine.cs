using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _topPanel;
    [SerializeField] private Player _player;
    [SerializeField] private ScoreManager _scoreManager;

    private bool _isTop;
    private const int UPBORDER = 1900;

    private void Update()
    {
        if (_topPanel.transform.position.y < UPBORDER && _isTop)
            _topPanel.transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        _player.NeedAddScore?.Invoke(300);
        _scoreManager.Multiplicator = 1;
        _isTop = true;
        StartCoroutine(Stop(0.2f));
    }
    
    private IEnumerator Stop(float timeInSec)
    {
        StartCoroutine(_player.Slowdown(timeInSec));
        
        yield return new WaitForSeconds(timeInSec + 0.3f);
        _finish.SetActive(true);
    }
}