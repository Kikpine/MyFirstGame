using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade_30mm : MonoBehaviour
{
    private float speed = 15f;
    public Rigidbody2D body;

    public float rotationSpeed = 3f;

    void Start()
    {
        body.velocity = transform.right * speed;
    }
    void Update()
    {
        // Поворачиваем ракету в направлении движения с плавным переходом
        RotateTowardsMovement();

        //
        //void OnTriggerEnter2D(Collider2D hitInfo)
        //{
        //    hit = true;
        //}
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(100);

        }
        Destroy(gameObject);
    }
}
