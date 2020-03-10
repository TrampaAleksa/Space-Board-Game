using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject buleltPrefab;

    public float bulletForce = 20f;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
       GameObject bullet= Instantiate(buleltPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb= bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
