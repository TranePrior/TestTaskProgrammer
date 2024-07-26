using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class BulletPool : IObjectPool<IBullet>
{
    public GameObject prefab { get; set; }
    
    private Queue<IBullet> pool;

    public BulletPool(GameObject bulletPrefab, GameConfig config)
    {
        prefab = bulletPrefab;
        pool = new Queue<IBullet>();

        for (int i = 0; i < config.bulletPoolSize; i++)
        {
            var bullet = Object.Instantiate(prefab).GetComponent<IBullet>();
            bullet.Init(config.bulletSpeed, config.bulletDamage);
            bullet.OnBulletFinishedLifetime += ReturnObjectToPool;
            pool.Enqueue(bullet);
            bullet.bulletGameObject.SetActive(false);
        }
    }

    public IBullet GetFirstAvailableObject()
    {
        var bullet = pool.Dequeue();
        pool.Enqueue(bullet);
        bullet.bulletGameObject.SetActive(true);
        return bullet;
    }

    public void ReturnObjectToPool(IBullet enemy)
    {
        enemy.bulletGameObject.SetActive(false);
        pool.Enqueue(enemy);
    }

    public void DisableAllObjects()
    {
        foreach (var obj in pool)
        {
            obj.bulletGameObject.SetActive(false);
        }
    }
}