using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade_30mm : MonoBehaviour
{
    private float speed = 15f;
    public Rigidbody2D body;
    void Start()
    {
        body.velocity = transform.right * speed;
    }

}
