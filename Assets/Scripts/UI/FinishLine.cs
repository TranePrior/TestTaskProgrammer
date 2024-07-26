using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FinishLine : MonoBehaviour
{
    public event Action<IEnemy> OnEnemyHitFinishLine;

    private Player _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IEnemy enemy))
        {
            enemy.OnEnemyFinishedLifetime?.Invoke(enemy);
            OnEnemyHitFinishLine?.Invoke(enemy);
        }
    }

    public void Init(Player player)
    {
        _player = player;
        OnEnemyHitFinishLine += _player.TakeDamage;
    }
    private void nDestroy()
    {
        OnEnemyHitFinishLine += _player.TakeDamage;
    }
}
