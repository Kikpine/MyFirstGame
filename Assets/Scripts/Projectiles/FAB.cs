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

    // ����� ��� ������������� �������� �����
    public void Initialize(Vector2 helicopterSpeed)
    {
        // ������������� �������� ����� ������ �������� ���������
        body.velocity = helicopterSpeed;
    }
}
