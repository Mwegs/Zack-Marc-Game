using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCannon : MonoBehaviour
{
    DashMove dashMove;
    [SerializeField] GameObject player;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    private float nextShotTime = 0;

    // Update is called once per frame
    void Awake()
    {
        dashMove = GameObject.Find("Player").GetComponent<DashMove>();
    }
    
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && dashMove.isDashing == false && Time.time > nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + fireRate;
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
