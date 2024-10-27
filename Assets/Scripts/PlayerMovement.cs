using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 newYPos;
    private float speed = 10f;
    public float GRAVITY = 1;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        body.gravityScale = GRAVITY;

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(0f, body.gravityScale);
        }

    }
}
