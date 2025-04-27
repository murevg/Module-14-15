using UnityEngine;

public class RotateToView : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    public void RotateTowards(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
