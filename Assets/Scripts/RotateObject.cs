using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float RotateSpeedObject;
    [SerializeField] private int AutoRotateSpeed;

    private Vector3 _rotation;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    _rotation = touch.deltaPosition.x switch
                    {
                        < -4 => Vector3.up,
                        > 4 => Vector3.down,
                        _ => Vector3.zero
                    };
                    transform.Rotate(_rotation * (RotateSpeedObject * Time.fixedDeltaTime));
                    break;
            }
        }
        else AutoRotate();
    }

    private void AutoRotate()
    {
        switch ((int)transform.rotation.eulerAngles.y)
        {
            case > 2 and < 45:
                transform.eulerAngles -= Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case >= 45 and < 88:
                transform.eulerAngles += Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case > 92 and < 135:
                transform.eulerAngles -= Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case >= 135 and < 178:
                transform.eulerAngles += Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case > 182 and < 225:
                transform.eulerAngles -= Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case >= 225 and < 268:
                transform.eulerAngles += Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case > 272 and < 315:
                transform.eulerAngles -= Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                break;
            case >= 315 and < 358:
                transform.eulerAngles += Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime);
                // transform.Rotate(Vector3.up * (AutoRotateSpeed * Time.fixedDeltaTime));
                break;
        }
    }
}