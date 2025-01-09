using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    public Rigidbody2D body;

    private int framesToStayHorizontal = 50; // ���������� ������, � ������� ������� ����� ����� ��������������
    private int currentFrame = 0; // ������� ����
    private float rotationSpeed = 2f; // �������� ��������

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // ������������� ��������� �������������� ���������
        transform.rotation = Quaternion.Euler(0, 0, 0); // ������������ �� 0 �������� ������ ��� Z
    }

    // ����� ��� ������������� �������� �����
    public void Initialize(Vector2 helicopterSpeed)
    {
        // ������������� �������� ����� ������ �������� ���������
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
            // ��������� ���� �������� �� ������ � �������
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
            enemy.TakeDamage(1000);
        }
        Destroy(gameObject);
    }
}