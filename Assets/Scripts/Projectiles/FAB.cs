using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    private float speed = 0f;
    public Rigidbody2D body;
    void Start()
    {
        body.velocity = transform.forward * speed;
    }
}
