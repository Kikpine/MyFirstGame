using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 10f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

    }
}
