using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Метод для инициализации скорости бомбы
    public void Initialize(Vector2 helicopterSpeed)
    {
        // Устанавливаем скорость бомбы равной скорости вертолета
        body.velocity = helicopterSpeed;
    }
}
