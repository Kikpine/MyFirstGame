using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAB : MonoBehaviour
{
    public Rigidbody2D body;

    private int framesToStayHorizontal = 200; // ���������� ������, � ������� ������� ����� ����� ��������������
    private int currentFrame = 0; // ������� ����
    public float rotationSpeed = 1f; // �������� ��������

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
            // ����������� ������� ������
            currentFrame++;
        }
        else
        {
            // ������������ ����� � ����������� �������� � ������� ���������
            RotateTowardsMovement();
        }
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
}
