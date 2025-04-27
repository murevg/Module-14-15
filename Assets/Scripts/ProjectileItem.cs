using UnityEngine;

public class ProjectileItem : Item
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private Transform _shootPoint;
    //[SerializeField] private float _lifeTime = 3f;

    [SerializeField] private GameObject _explosionParticlesPrefab;

    public override void Use(Player player)
    {
        GameObject projectile = Instantiate(_projectilePrefab, _shootPoint.position + player.transform.forward, Quaternion.identity);
        Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
        rigidBody.velocity = player.transform.forward * _projectileSpeed;
        //Destroy(projectile, _lifeTime);
        Destroy(gameObject);
    }

    public void SetShootPoint(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }
}
