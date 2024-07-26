using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform firePoint;
    private float _attackRadius;
    private float _fireRate;
    private IPooledFactory<IBullet> bulletFactory;
    private float nextFireTime;
    private bool shouldStopFire;

    private void Awake()
    {
        firePoint = GetComponent<Transform>();
    }

    public void Init(IPooledFactory<IBullet> bulletFactory, GameConfig gameConfig)
    {
        this.bulletFactory = bulletFactory;
        _fireRate = gameConfig._fireRate;
        _attackRadius = gameConfig._àttackRadius;
    }

    public void Stop()
    {
        shouldStopFire = true;
    }

    private void Update()
    {
        if (Time.time < nextFireTime || shouldStopFire) return;

        var nearestEnemy = SearchForNearestEnemy();

        if (nearestEnemy == null) return;

        Shoot(nearestEnemy);
        nextFireTime = Time.time + 1f / _fireRate;
    }

    private IEnemy SearchForNearestEnemy()
    {
        var hitColliders = GetEnemiesWithinRadius();
        var nearestEnemyCollider = GetNearestEnemyCollider(hitColliders);

        return nearestEnemyCollider != null && nearestEnemyCollider.TryGetComponent(out IEnemy nearestEnemy)
            ? nearestEnemy
            : null;
    }

    private Collider2D[] GetEnemiesWithinRadius()
    {
        return Physics2D.OverlapCircleAll(transform.position, _attackRadius);
    }

    private Collider2D GetNearestEnemyCollider(Collider2D[] colliders)
    {
        Collider2D nearestCollider = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IEnemy enemy))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestCollider = collider;
                }
            }
        }

        return nearestCollider;
    }

    private void Shoot(IEnemy target)
    {
        var bullet = bulletFactory.GetNewObject();
        bullet.StartMoving(firePoint, target);
    }
}
