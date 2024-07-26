using System;
using UnityEngine;

public interface IEnemy
{
    GameObject enemyGameObject { get; }
    Action<IEnemy> OnEnemyFinishedLifetime { get; set; }
    void Init(GameConfig gameConfig);
    void StartMoving(Vector2 startPoint);
    void TakeDamage(int damage);
    bool IsAlive();
    void Reset();
}