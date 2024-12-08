using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    public Rigidbody2D body;

    private int framesToStayHorizontal = 200; // Количество кадров, в течение которых бомба будет горизонтальной
    private int currentFrame = 0; // Текущий кадр
    public float rotationSpeed = 1f; // Скорость вращения

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
            // Увеличиваем счетчик кадров
            currentFrame++;
        }
        else
        {
            // Поворачиваем бомбу в направлении движения с плавным переходом
            RotateTowardsMovement();
        }
    }

    private void RotateTowardsMovement()
    {
        // Проверяем, есть ли скорость
        if (body.velocity != Vector2.zero)
        {
            // Вычисляем угол поворота
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;

            // Создаем кватернион для нового угла
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Плавно поворачиваем в сторону нового угла
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
