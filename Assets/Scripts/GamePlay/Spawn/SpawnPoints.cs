using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    private IPooledFactory<IEnemy> _enemyFactory;
    private Coroutine _spawnCoroutine;
    
    public void Init(IPooledFactory<IEnemy> factory)
    {
        _enemyFactory = factory;
        _spawnCoroutine = StartCoroutine(StartSpawnLoop());
    }
    
    public void Stop()
    {
        if (_spawnCoroutine != null)
        {
            _enemyFactory.DisableAllObjects();
            StopCoroutine(_spawnCoroutine);
        }
    }

    private IEnumerator StartSpawnLoop()
    {
        while (true)
        {
            var enemy = _enemyFactory.GetNewObject();
            var spawnIndex = Random.Range(0, spawnPoints.Count);
            enemy.StartMoving(spawnPoints[spawnIndex].position);
            yield return new WaitForSeconds(1f);
        }
    }
}