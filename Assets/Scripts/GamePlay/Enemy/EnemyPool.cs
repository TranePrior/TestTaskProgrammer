using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : IObjectPool<IEnemy>
{
    public GameObject prefab { get; set; }
    private Queue<IEnemy> pool;
    private WinnerListener winnerListener;

    public EnemyPool(GameObject enemyPrefab, int size, WinnerListener winnerListener)
    {
        prefab = enemyPrefab;
        pool = new Queue<IEnemy>();
        this.winnerListener = winnerListener;

        for (int i = 0; i < size; i++)
        {
            var enemy = Object.Instantiate(prefab).GetComponent<IEnemy>();
            enemy.OnEnemyFinishedLifetime += ReturnObjectToPool;
            pool.Enqueue(enemy);
            enemy.enemyGameObject.SetActive(false);
        }
    }

    public IEnemy GetFirstAvailableObject()
    {
        var enemy = pool.Dequeue();
        pool.Enqueue(enemy);
        enemy.enemyGameObject.SetActive(true);
        return enemy;
    }

    public void ReturnObjectToPool(IEnemy enemy)
    {
        enemy.enemyGameObject.SetActive(false);
        
        if (!enemy.IsAlive())
        {
            winnerListener.OnEnemyDied();
        }
        
        enemy.Reset();
        pool.Enqueue(enemy);
    }

    public void DisableAllObjects()
    {
        foreach (var obj in pool)
        {
            obj.enemyGameObject.SetActive(false);
        }
    }
}