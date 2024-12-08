using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_12_7mm : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D body;
    void Start()
    {
        body.velocity = transform.right * speed;
    }

}
