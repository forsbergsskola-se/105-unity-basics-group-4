using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring;
    public BulletControll bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControll newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletControll;
                newBullet.speed = bulletSpeed;
            }
            else
            {
                shotCounter = 0;
            }
        }
    }
}
