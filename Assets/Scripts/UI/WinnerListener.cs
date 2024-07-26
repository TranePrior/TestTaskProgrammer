using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WinnerListener : MonoBehaviour
{
    [SerializeField] private GameObject playerHealth;
    [SerializeField] private GameObject winnerScreen;
    
    private int _enemyCountToWin;
    public Action OnWin { get; set; }
    public void Init(GameConfig config)
    {
        var enemyCountToWin = Random.Range(config.enemiesToDestroyRange.x, config.enemiesToDestroyRange.y);
        _enemyCountToWin = enemyCountToWin;
    }
    
    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnEnemyDied()
    {
        _enemyCountToWin--;
        
        if (_enemyCountToWin <= 0)
        {
            playerHealth.SetActive(false);
            winnerScreen.SetActive(true);
            OnWin?.Invoke();
        }
    }
}
