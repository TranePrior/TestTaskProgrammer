using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private Player player;
    [SerializeField] private FinishLine finishLine;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private HealthView healthView;
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private WinnerListener winnerListener;
    [SerializeField] private GameOverListener gameOverListener;

    private IPooledFactory<IEnemy> asteroidFactory;
    private IPooledFactory<IBullet> bulletFactory;

    private void Start()
    {
        InjectDependencies();
        InitObjects();
    }

    private void InjectDependencies()
    {

        IObjectPool<IEnemy> asteroidPool = new EnemyPool(asteroidPrefab, gameConfig.enemyPoolSize, winnerListener);
        IObjectPool<IBullet> bulletPool = new BulletPool(bulletPrefab, gameConfig);
        asteroidFactory = new AsteroidFactory(asteroidPool, gameConfig);
        bulletFactory = new BulletFactory(bulletPool);
    }

    private void InitObjects()
    {
        asteroidSpawner.Init(asteroidFactory);
        gun.Init(bulletFactory, gameConfig);
        player.Init(gameConfig.playerHealth);
        finishLine.Init(player);
        healthView.Init(player);
        winnerListener.Init(gameConfig);
        gameOverListener.Init();
        winnerListener.OnWin += StopObjects;
        gameOverListener.OnFail += StopObjects;
    }

    private void StopObjects()
    {
        asteroidSpawner.Stop();
        gun.Stop();
    }

    private void OnDestroy()
    {
        winnerListener.OnWin -= StopObjects;
        gameOverListener.OnFail -= StopObjects;
    }
}
