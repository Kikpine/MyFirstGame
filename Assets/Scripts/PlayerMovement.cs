using System.Drawing;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private float engineSpeed = 1000;
    private float engineDelta = 0.04f;
    private float rotateSpeed = 50;
    private float rosh = 0f;
    //public float speedX;
    //public float speedY;
    //public float propellerMAXRpm;
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
        body.AddForce(transform.up * engineSpeed * Time.deltaTime * rosh / 150);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotateSpeed*Time.deltaTime*Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotateSpeed*Time.deltaTime*Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow) && rosh > 0.1f)
        {
            rosh -= engineDelta;
        }
        if (Input.GetKey(KeyCode.UpArrow) && rosh < 99.9f)
        {
            rosh += engineDelta;
        }

    }
}

// +-40% РОШ - висение

// 192 оборотов НВ в минуту - 100%