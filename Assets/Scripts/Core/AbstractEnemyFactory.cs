using System;

public abstract class AbstractEnemyFactory : IPooledFactory<IEnemy>
{
    public IObjectPool<IEnemy> enemyPool;

    public Action OnObjectLifetimeFinished { get; set; }

    protected GameConfig gameConfig;

    protected AbstractEnemyFactory(IObjectPool<IEnemy> enemyPool, GameConfig gameConfig)
    {
        this.enemyPool = enemyPool;
        this.gameConfig = gameConfig;
    }

    public abstract IEnemy GetNewObject();

    public void DisableAllObjects()
    {
        enemyPool.DisableAllObjects();
    }

    protected void ReturnObjectToPool(IEnemy enemy)
    {
        enemy.OnEnemyFinishedLifetime -= ReturnObjectToPool;
        enemyPool.ReturnObjectToPool(enemy);
    }
}