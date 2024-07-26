using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(EnemyMovement))]

public class Asteroid : MonoBehaviour, IEnemy
{
    private GameConfig gameConfig;
    private float _speed;
    private int _baseHealth;
    private int _currentHealth;
    public GameObject enemyGameObject => gameObject;
    public Action<IEnemy> OnEnemyFinishedLifetime { get; set; }
    public void Init(GameConfig gameConfig)
    {
        this.gameConfig = gameConfig;
        _speed = Random.Range(gameConfig.enemySpeedRange.x, gameConfig.enemySpeedRange.y);
        _baseHealth = gameConfig.enemyHealth;
        _currentHealth = _baseHealth;
        var enemyMovement = GetComponent<EnemyMovement>();
        enemyMovement.Init(gameConfig);
    }

    public void StartMoving(Vector2 startPoint)
    {
        enemyGameObject.transform.position = startPoint;
        enemyGameObject.SetActive(true);
        StartCoroutine(Move());
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth > 0) return;
        
        OnEnemyFinishedLifetime?.Invoke(this);
    }

    public bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public void Reset()
    {
        _currentHealth = _baseHealth;
    }

    private IEnumerator Move()
    {
        while (enemyGameObject.activeSelf)
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
            yield return null;
        }
    }
}