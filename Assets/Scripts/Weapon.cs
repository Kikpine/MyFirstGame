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
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
    }

    void Update()
    {
        if (Input.GetButtonDown("7.62mm"))
        {
            Shoot_7_62mm();
        }
        if (Input.GetButtonDown("12.7mm"))
        {
            Shoot_12_7mm();
        }
        if (Input.GetButtonDown("23mm"))
        {
            Shoot_23mm();
        }
        if (Input.GetButtonDown("30mm(AGS)"))
        {
            Shoot_30mm();
        }
        if (Input.GetButtonDown("80mm(NAR)"))
        {
            Shoot_80mm();
        }
        if (Input.GetButtonDown("FAB"))
        {
            Shoot_FAB();
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
    void Shoot_80mm()
    {
        Instantiate(rocket_80mm, firePoint.position, firePoint.rotation);
    }
    void Shoot_FAB()
    {
        GameObject bombInstance = Instantiate(bomb, firePoint.position, firePoint.rotation);
        // �������� �������� ��������� � �������� � ��� �����
        FAB bombScript = bombInstance.GetComponent<FAB>();

        if (bombScript != null)
        {
            bombScript.Initialize(playerMovement.GetCurrentVelocity());
        }
    }
}