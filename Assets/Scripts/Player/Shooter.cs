using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject firePointRight;
    [SerializeField] GameObject firePointLeft;
    GameObject firePointToUse;
    [SerializeField] GameObject projectile;

    [SerializeField] float fireRate;
    [SerializeField] float projectileLifetime = 2f;
    GameObject tempProjectile;
    float nextFire;

    public bool hasWeapon = true;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasWeapon)
            return;

        if (playerMovement.isLookingRight)
            firePointToUse = firePointRight;
        else
            firePointToUse = firePointLeft;

        if (Input.GetButtonDown("Fire1"))
        {
            SetupShot();
        }
    }

    public void SetupShot()
    {
        if (Time.time > nextFire)
        {
            MakeAShot();
            nextFire = Time.time + 1 / fireRate;
        }
    }

    void MakeAShot()
    {
        CreateProjectile();
        //Add vfx here 
    }

    void CreateProjectile()
    {
        tempProjectile = Instantiate(projectile, firePointToUse.transform.position, firePointToUse.transform.rotation);
        Destroy(tempProjectile, projectileLifetime);
    }
}
