using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverListener : MonoBehaviour
{
    [SerializeField] private GameObject playerHealth;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Player player;

    private int _enemyCountToWin;
    public Action OnFail { get; set; }

    public void Init()
    {
        player.OnPlayerHealthChanged += OnPlayerHealthChanged;
    }
    
    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnPlayerHealthChanged()
    {
        if (player.Health > 0) return;
        playerHealth.SetActive(false);
        gameOverScreen.SetActive(true);
        OnFail?.Invoke();
    }
}