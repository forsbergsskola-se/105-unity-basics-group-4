using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunScript : MonoBehaviour
{
  
    //stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool autoFire;
    private int bulletsLeft, bulletsShot;
    
    //bools
    private bool shooting, readyToShoot, reloading;
    
    //references
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public Camera gunCamera;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        PlayerInput();
    }
    
    
    
    private void PlayerInput()
    {
       if (autoFire) shooting = Input.GetKey(KeyCode.Mouse0);
       else shooting = Input.GetKeyDown(KeyCode.Mouse0);

       if (Input.GetKey(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
       
       //shoot
       if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
       {
           bulletsShot = bulletsPerTap;
           Shoot();
       }
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Shoot()
    {
        readyToShoot = false;
        
        //spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //raycast
        if (Physics.Raycast(gunCamera.transform.position, gunCamera.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy")) ;

        }
        
        bulletsLeft--;
        bulletsShot--;
        
        Invoke("ResetShot", timeBetweenShooting);
        
        if (bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
}
