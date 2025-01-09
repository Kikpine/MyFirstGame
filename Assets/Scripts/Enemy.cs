using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;
    public float health = 1000;

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

}
