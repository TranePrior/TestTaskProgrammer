using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float screenWidth = 5f;
    public float screenHeight = 10f;
    public float finishLineY = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;

        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenWidth, screenWidth);
        pos.y = Mathf.Clamp(pos.y, -screenHeight, finishLineY);
        transform.position = pos;
    }
}
