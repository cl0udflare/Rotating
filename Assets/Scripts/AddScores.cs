using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AddScores : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnPosition;
    [SerializeField] private float _speed = 600;
    [SerializeField] private float _lifeTime = 1f;
    
    private TextMeshProUGUI _scoreText;
    private RectTransform _rectTransform;

    private bool isBold;
    
    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfter(_lifeTime));
    }

    private void Update()
    {
        // _rectTransform.anchoredPosition = Vector3.MoveTowards(
        //     _rectTransform.anchoredPosition,
        //     _rectTransform.anchoredPosition + Vector2.up,
        //     _speed * Time.deltaTime);
        if (isBold)
            _rectTransform.anchoredPosition += Vector2.up * (_speed * Time.deltaTime);
        else
            _rectTransform.anchoredPosition += Vector2.up * (_speed / 2 * Time.deltaTime);
    }

    public void Init(int amount)
    {
        if (amount == 1)
        {
            _rectTransform.anchoredPosition = _spawnPosition;
            isBold = true;
        }
        else
        {
            _rectTransform.anchoredPosition = _spawnPosition + Vector2.right * 50;
            isBold = false;
        }
    }
    public void SetScore(int value)
    {
        _scoreText.text = "+" + value;
    }
    public void SetFontSize(float size)
    {
        _scoreText.fontSize = size;
    }
    public void SetFontStyle(FontStyles style)
    {
        _scoreText.fontStyle = style;
    }

    private IEnumerator DestroyAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
