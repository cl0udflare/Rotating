using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    
    private float _fastSpeed => _defaultSpeed * 2f;
    private float _nextActionTime;
    private bool _isForwardMove = true;
    private bool _canMove;
    private bool _canRepeat = true;
    
    public Action<int> NeedAddScore; 
    
    public float CurrentSpeed { get; private set; }
    
    private void Start() => CurrentSpeed = _defaultSpeed;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Stationary:
                    if (_isForwardMove)
                    {
                        CurrentSpeed = _fastSpeed;
                        if (_canRepeat)
                        {
                            NeedAddScore?.Invoke(1);
                            StartCoroutine(Repeat());
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (_isForwardMove) CurrentSpeed = _defaultSpeed;
                    break;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_canMove)
            // _rigidbody.velocity = Vector3.forward * (CurrentSpeed * Time.fixedDeltaTime);
            transform.position += Vector3.forward * (CurrentSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var greenCube = collision.gameObject.GetComponent<GrateCubesForce>();
        if (greenCube == null) return;
        
        StartCoroutine(MoveBack(0.5f));
    }
    private void OnTriggerEnter(Collider other)
    {
        var passingGrate = other.GetComponent<PassingGrate>();
        
        if(passingGrate != null)
            NeedAddScore?.Invoke(GrateCubesForce.IsClearPass ? 10 : 5);
    }

    public void CanMove(bool state) =>  _canMove = state;

    private IEnumerator MoveBack(float timeInSec)
    {
        _isForwardMove = false;
        CurrentSpeed = _defaultSpeed / -2f;
        yield return new WaitForSeconds(timeInSec);
        CurrentSpeed = _defaultSpeed;
        _isForwardMove = true;
    }
    
    public IEnumerator Slowdown(float timeInSec)
    {
        _isForwardMove = false;
        yield return new WaitForSeconds(timeInSec);
        CurrentSpeed = _defaultSpeed / 2f;
        yield return new WaitForSeconds(timeInSec + 0.2f);
        CurrentSpeed = 0;
    }
    
    private IEnumerator Repeat()
    {
        _canRepeat = false;
        yield return new WaitForSeconds(0.2f);
        _canRepeat = true;
    }
    
}