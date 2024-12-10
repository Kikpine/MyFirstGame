using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet_7_62mm;
    public GameObject bullet_12_7mm;
    public GameObject bullet_23mm;
    public GameObject granade_30mm;
    public GameObject rocket_80mm;
    public GameObject bomb;

    private PlayerMovement playerMovement;

    private Coroutine shootingCoroutine_7_62mm; // ������ �� �������� ��������
    private Coroutine shootingCoroutine_12_7mm; // ������ �� �������� ��������
    private Coroutine shootingCoroutine_23mm; // ������ �� �������� ��������
    private Coroutine shootingCoroutine_30mm; // ������ �� �������� ��������


    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("7.62mm"))
        {
            StartShooting_7_62mm();
        }
        if (Input.GetButtonDown("12.7mm"))
        {
            StartShooting12_7mm();
        }
        if (Input.GetButtonDown("23mm"))
        {
            StartShooting23mm();
        }
        if (Input.GetButtonDown("30mm(AGS)"))
        {
            StartShooting30mm();
        }
        if (Input.GetButtonDown("80mm(NAR)"))
        {
            Shoot_80mm();
        }
        if (Input.GetButtonDown("FAB"))
        {
            Shoot_FAB();
        }

        // ��������� �������� ��� ���������� ������
        if (Input.GetButtonUp("7.62mm") && shootingCoroutine_7_62mm != null)
        {
            StopCoroutine(shootingCoroutine_7_62mm);
            shootingCoroutine_7_62mm = null; // ���������� ������ �� ��������
        }
        if (Input.GetButtonUp("12.7mm") && shootingCoroutine_12_7mm != null)
        {
            StopCoroutine(shootingCoroutine_12_7mm);
            shootingCoroutine_12_7mm = null; // ���������� ������ �� ��������
        }
        if (Input.GetButtonUp("23mm") && shootingCoroutine_23mm != null)
        {
            StopCoroutine(shootingCoroutine_23mm);
            shootingCoroutine_23mm = null; // ���������� ������ �� ��������
        }
        if (Input.GetButtonUp("30mm(AGS)") && shootingCoroutine_30mm != null)
        {
            StopCoroutine(shootingCoroutine_30mm);
            shootingCoroutine_30mm = null; // ���������� ������ �� ��������
        }
    }

    void Shoot_7_62mm()
    {
        Instantiate(bullet_7_62mm, firePoint.position, firePoint.rotation);
    }
    void Shoot_12_7mm()
    {
        Instantiate(bullet_12_7mm, firePoint.position, firePoint.rotation);
    }
    void Shoot_23mm()
    {
        Instantiate(bullet_23mm, firePoint.position, firePoint.rotation);
    }    
    void Shoot_30mm()
    {
        Instantiate(granade_30mm, firePoint.position, firePoint.rotation);
    }

    // 7.62
    void StartShooting_7_62mm()
    {
        if (shootingCoroutine_7_62mm == null) // ���������, �� �������� �� ��� ��������
        {
            shootingCoroutine_7_62mm = StartCoroutine(ImShoot7_62mm());
        }
    }

    IEnumerator ImShoot7_62mm()
    {
        while (true) // ����������� ���� ��� ��������
        {
            Shoot_7_62mm(); // �������� ����� ��������
            yield return new WaitForSeconds(0.09f); // ���� 0.09 ������� ����� ���������� (�������� 11 �������� � �������) - ����� 700 ��������� � ������
        }
    }
    // 12.7
    void StartShooting12_7mm()
    {
        if (shootingCoroutine_12_7mm == null) // ���������, �� �������� �� ��� ��������
        {
            shootingCoroutine_12_7mm = StartCoroutine(ImShoot12_7mm());
        }
    }

    IEnumerator ImShoot12_7mm()
    {
        while (true) // ����������� ���� ��� ��������
        {
            Shoot_12_7mm(); // �������� ����� ��������
            yield return new WaitForSeconds(0.1f); // ���� 0.1 ������� ����� ���������� (10 �������� � �������) - 600 ��������� � ������
        }
    }
    // 23
    void StartShooting23mm()
    {
        if (shootingCoroutine_23mm == null) // ���������, �� �������� �� ��� ��������
        {
            shootingCoroutine_23mm = StartCoroutine(ImShoot23mm());
        }
    }

    IEnumerator ImShoot23mm()
    {
        while (true) // ����������� ���� ��� ��������
        {
            Shoot_23mm(); // �������� ����� ��������
            yield return new WaitForSeconds(0.017f); // ����  ������� ����� ���������� (53 �������� � �������) - 3200 ��������� � ������
        }
    }

    void StartShooting30mm()
    {
        if (shootingCoroutine_30mm == null) // ���������, �� �������� �� ��� ��������
        {
            shootingCoroutine_30mm = StartCoroutine(ImShoot30mm());
        }
    }

    IEnumerator ImShoot30mm()
    {
        while (true) // ����������� ���� ��� ��������
        {
            Shoot_30mm(); // �������� ����� ��������
            yield return new WaitForSeconds(0.1f); // ����  ������� ����� ���������� (10 �������� � �������) - 600 ��������� � ������
        }
    }

    void Shoot_80mm()
    {
        Instantiate(rocket_80mm, firePoint.position, firePoint.rotation);
    }

    void Shoot_FAB()
    {
        GameObject bombInstance = Instantiate(bomb, firePoint.position, firePoint.rotation);

        // �������� �������� ��������� � �������� � � �����
        FAB bombScript = bombInstance.GetComponent<FAB>();

        if (bombScript != null)
        {
            bombScript.Initialize(playerMovement.GetCurrentVelocity());
        }
    }
}
