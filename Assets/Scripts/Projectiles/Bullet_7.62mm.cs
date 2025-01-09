using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_7_62mm : MonoBehaviour
{
    private float speed = 25f;
    public Rigidbody2D body;
    public float rotationSpeed = 3f;

    void Start()
    {
        body.velocity = transform.right * speed;
    }
    void Update()
    {
        // ������������ ������ � ����������� �������� � ������� ���������
        RotateTowardsMovement();
    }
    private void RotateTowardsMovement()
    {
        // ���������, ���� �� ��������
        if (body.velocity != Vector2.zero)
        {
            // ��������� ���� ��������
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;

            // ������� ���������� ��� ������ ����
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // ������ ������������ � ������� ������ ����
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(10);
        }
        Destroy(gameObject);

    }
}
