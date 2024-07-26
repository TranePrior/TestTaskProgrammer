using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config", order = 1)]
public class GameConfig : ScriptableObject
{
    [Header("Enemy Settings")]
    [Tooltip("The range of enemies to destroy for victory.")]
    public Vector2Int enemiesToDestroyRange = new Vector2Int(10, 20);
    [Tooltip("The range of time intervals (in seconds) for enemy spawn.")]
    public Vector2 enemySpawnTimeoutRange = new Vector2(1.0f, 3.0f);
    [Tooltip("The range of movement speeds for enemies.")]
    public Vector2 enemySpeedRange = new Vector2(1.0f, 3.0f);
    [Tooltip("The health of each enemy.")]
    public int enemyHealth = 5;
    [Tooltip("Enemy pool size.")]
    public int enemyPoolSize = 5;
    [Tooltip("The speed of enemies.")]
    public float enemySpeed = 2.0f;

    [Header("Player Settings")]
    [Tooltip("The attack (shooting) radius of the player.")]
    public float _àttackRadius = 5.0f;
    [Tooltip("The shooting speed (rate) of the player.")]
    public float _fireRate = 1.0f;
    [Tooltip("The damage dealt by the player's shots.")]
    public int bulletDamage = 10;
    [Tooltip("The speed of the player's bullets.")]
    public float bulletSpeed = 10.0f;
    [Tooltip("Bullets pool size.")]
    public int bulletPoolSize = 5;
    [Tooltip("Starting health of the player.")]
    public int playerHealth = 5;
}