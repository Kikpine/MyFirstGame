using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_7_62mm : MonoBehaviour
{
    private float speed = 25f;
    public Rigidbody2D body;
    void Start()
    {
        body.velocity = transform.right * speed;
    }

}
