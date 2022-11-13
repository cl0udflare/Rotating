using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject _tapToStart;
    [SerializeField] private Player _player;
    
    private void FixedUpdate()
    {
        if (!_tapToStart.activeSelf)
            transform.position += Vector3.forward * (_player.CurrentSpeed * Time.fixedDeltaTime);
    }
}
