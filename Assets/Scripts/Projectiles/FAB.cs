using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    public Rigidbody2D body;

    private int framesToStayHorizontal = 50; // Количество кадров, в течение которых бомба будет горизонтальной
    private int currentFrame = 0; // Текущий кадр
    private float rotationSpeed = 2f; // Скорость вращения

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // Устанавливаем начальное горизонтальное положение
        transform.rotation = Quaternion.Euler(0, 0, 0); // Поворачиваем на 0 градусов вокруг оси Z
    }

    // Метод для инициализации скорости бомбы
    public void Initialize(Vector2 helicopterSpeed)
    {
        // Устанавливаем скорость бомбы равной скорости вертолета
        body.velocity = helicopterSpeed;
    }

    void Update()
    {
        if (currentFrame < framesToStayHorizontal)
        {
            currentFrame++;
        }
        else
        {
            RotateTowardsMovement();
        }
    }

    private void RotateTowardsMovement()
    {
        if (body.velocity != Vector2.zero)
        {
            // Вычисляем угол поворота из радиан в градусы
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;

            // Создаем кватернион для нового угла
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Плавно поворачиваем в сторону нового угла
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(1000);
        }
        Destroy(gameObject);
    }
}