using System;
using UnityEngine;

public interface IBullet 
{
    GameObject bulletGameObject { get; }
    Action<IBullet> OnBulletFinishedLifetime { get; set; }
    void Init(float speed, int damage);
    void StartMoving(Transform spawnPoint, IEnemy target);
}
