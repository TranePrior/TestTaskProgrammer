public class AsteroidFactory : AbstractEnemyFactory
{
    public AsteroidFactory(IObjectPool<IEnemy> enemyPool, GameConfig gameConfig) : base(enemyPool, gameConfig)
    {
     
    }

    
    public override IEnemy GetNewObject()
    {
        var enemy = enemyPool.GetFirstAvailableObject();
        enemy.Init(gameConfig);
        enemy.OnEnemyFinishedLifetime += ReturnObjectToPool;
        return enemy;
    }
}