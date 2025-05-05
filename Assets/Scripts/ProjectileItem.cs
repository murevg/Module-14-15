using UnityEngine;

public class ProjectileItem : Item
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private GameObject _explosionParticlesPrefab;

    public override void Use(GameObject user)
    {
        Player player = user.GetComponent<Player>();

        if (player != null)
        {
            Vector3 spawnPosition = _shootPoint.position;
            Vector3 direction = player.transform.forward;

            Projectile projectile = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.Launch(direction, _projectileSpeed);

            Destroy(gameObject);
        }
    }
}
