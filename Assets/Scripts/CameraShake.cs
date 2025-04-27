using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeMagnitude;

    private Vector3 _originalPosition;
    private float _shakeTimer;

    private void Awake()
    {
        Instance = this;
        _originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if(_shakeTimer > 0)
        {
            transform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeMagnitude;

            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = _originalPosition;
        }
    }

    public void Shake()
    {
        _shakeTimer = _shakeDuration;
    }
}
