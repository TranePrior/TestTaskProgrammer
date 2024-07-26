using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 5;
    public Action OnPlayerHealthChanged { get; set; }
    public int Health => _health;

    public void Init(int health)
    {
        _health = health;
    }

    public void TakeDamage(IEnemy enemy)
    {
        _health -= 1;
        OnPlayerHealthChanged?.Invoke();
    }
}
