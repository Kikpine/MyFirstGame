using System.Drawing;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private float engineSpeed = 1000;
    private float engineDelta = 0.05f; // DELETE ON RELEASE
    private float rotateSpeed = 50; 
    [SerializeField] private float rosh = 0f;
    private float rotateSide = 1f;

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
            transform.Rotate(rotateSpeed*rotateSide*Time.deltaTime*Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotateSpeed*rotateSide*Time.deltaTime*Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow) && rosh > 0.1f)
        {
            rosh -= engineDelta;
        }
        if (Input.GetKey(KeyCode.UpArrow) && rosh < 99.9f)
        {
            rosh += engineDelta;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 180f, 0);
            rotateSide *= -1;
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            rosh = 73.545f;
        }


    }
    public Vector2 GetCurrentVelocity()
    {
        return body.velocity;
    }
}

// +-40% РОШ - висение
//
// 192 оборотов НВ в минуту - 100%