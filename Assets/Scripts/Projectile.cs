using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private GameObject _explosionParticlesPrefab;
    [SerializeField] private float _explosionYOffset = -0.5f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _lifeTime)
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (_explosionParticlesPrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0f, _explosionYOffset, 0f);
            GameObject explosion = Instantiate(_explosionParticlesPrefab, spawnPosition, Quaternion.identity);
            Destroy(explosion, 2f);
        }

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake();
        }

        Destroy(gameObject);
    }
}