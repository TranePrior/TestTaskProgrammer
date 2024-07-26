using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed; 
    private GameConfig gameConfig;
    public void Init(GameConfig config)
    {
        speed = config.enemySpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
