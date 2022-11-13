using UnityEngine;

public class StartGameInstructions : MonoBehaviour
{
    [SerializeField] private GameObject _tapToStart;
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            _player.CanMove(true);
            _tapToStart.SetActive(false);
        }

        if (!_tapToStart.activeSelf)
        {
            if (_camera.transform.eulerAngles.y < 355)
                _camera.transform.eulerAngles += Vector3.up * (22 * Time.fixedDeltaTime);

            if (_camera.transform.position.x > 2.3)
                _camera.transform.position -= new Vector3(5 * Time.fixedDeltaTime, 0, 1 * Time.fixedDeltaTime);
        }
    }
}
