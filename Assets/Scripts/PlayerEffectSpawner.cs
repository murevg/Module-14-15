using UnityEngine;

public class PlayerEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _speedBuffEffectPrefab;
    [SerializeField] private GameObject _healthBuffEffectPrefab;

    public void SpawnSpeedBuffEffect()
    {
        if (_speedBuffEffectPrefab != null)
        {
            GameObject effect = Instantiate(_speedBuffEffectPrefab, transform.position, Quaternion.identity);
            effect.transform.SetParent(transform);
            Destroy(effect, 2f);
        }
    }

    public void SpawnHealthBuffEffect()
    {
        if (_healthBuffEffectPrefab != null)
        {
            GameObject effect = Instantiate(_healthBuffEffectPrefab, transform.position, Quaternion.identity);
            effect.transform.SetParent(transform);
            Destroy(effect, 2f);
        }
    }
}
