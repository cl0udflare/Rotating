using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrateCubesForce : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    [NonSerialized] public static bool IsClearPass = true;
    
    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    private Transform _transform;
    private const float Push = 500f;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _transform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player == null) return;

        _rigidbody.isKinematic = false;
        if (Random.Range(0, 2) == 0)
            _rigidbody.AddForce(new Vector3(0, 0, 1) * Push);
        else
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z - 1.5f);
        
        _collider.size = Vector3.zero; 
        _collider.center = new Vector3(0, -0.5f, 0);

        IsClearPass = false;
        _scoreManager.Multiplicator = 1;
    }
    
}