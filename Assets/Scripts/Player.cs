using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    public int Health => _health;
    public float Speed => _speed;

    private PlayerEffectSpawner _effectSpawner;

    private void Awake()
    {
        _effectSpawner = GetComponent<PlayerEffectSpawner>();
    }

    public void IncreaseHealth(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("IncreaseHealth: передано отрицательное значение! Это невалидно.");
            return;
        }

        _health += amount;
        Debug.Log("Твое Здоровье: " + Health);

        if(_effectSpawner != null)
        {
            _effectSpawner.SpawnHealthBuffEffect();
        }
    }

    public void IncreaseSpeed(float amount)
    {
        if (amount < 0f)
        {
            Debug.LogError("IncreaseSpeed: передано отрицательное значение! Это невалидно.");
            return;
        }

        _speed += amount;
        Debug.Log("Твоя Скорость: " + Speed);

        if (_effectSpawner != null)
        {
            _effectSpawner.SpawnSpeedBuffEffect();
        }
    }
}
