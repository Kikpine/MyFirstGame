using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAR : MonoBehaviour
{
    private float speed = 20f;
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
}
