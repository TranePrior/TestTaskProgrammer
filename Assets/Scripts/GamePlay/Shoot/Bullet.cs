using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    private Transform spawnPoint;
    private IEnemy target;
    private float speed;
    private int damage;

    public GameObject bulletGameObject => gameObject;
    public Action<IBullet> OnBulletFinishedLifetime { get; set; }

    public void Init(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    public void StartMoving(Transform spawnPoint, IEnemy target)
    {
        this.spawnPoint = spawnPoint;
        this.target = target;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        transform.position = spawnPoint.position;

        while (true)
        {
            if (target == null)
            {
                OnBulletFinishedLifetime?.Invoke(this);
                yield break;
            }

            Vector2 direction = (target.enemyGameObject.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IEnemy enemy))
        {
            enemy.TakeDamage(damage);
            OnBulletFinishedLifetime?.Invoke(this);
        }
    }
}