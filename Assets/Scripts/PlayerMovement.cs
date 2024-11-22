using System.Drawing;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private float engineSpeed = 1000;

    //public float speedX;
    //public float speedY;
    //public float propellerMAXRpm;
    //public float rosh;
    //public float GRAVITY = 1;
    //public float mass;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //body.gravityScale = GRAVITY;
        //body.velocity = Vector2.zero;
        //body.mass = 7.2f;

        ////engineSpeed  = 0f;
        ////propellerMAXRpm = 192f;
        //rosh = 0f; // РОШ в %

        //speedX = 5f;
        //speedY = 50f;

    }
    void Update()
    {
        //body.velocity = new Vector2(Input.GetAxis("Horizontal") * speedX, (rosh / 100f * speedY / body.mass) - (body.gravityScale * 5));

        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddForce(transform.up * engineSpeed * Time.deltaTime);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    body.AddForce(transform.up * rosh, ForceMode2D.Impulse);
        //}

        //if (Input.GetKey(KeyCode.DownArrow) && rosh > -0.1f)
        //{
        //    rosh -= 0.1f;
        //}
    }
}

// 45% РОШ - висение
// 36% РОШ - отрыв

// 192 оборотов НВ в минуту - 100%