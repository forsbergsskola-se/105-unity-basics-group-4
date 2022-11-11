using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public PlayerMovement playermovement;
    public BulletControll bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public float shotgunSpread;
    public int shotgunPelletAmount;
    int daddy;


    void Update()
    {
        
        shotCounter += Time.deltaTime;
        if (playermovement.autoFire)
        {
            if (shotCounter >= timeBetweenShots)
            {
                float x = Random.Range(-shotgunSpread, shotgunSpread);
                float y = Random.Range(-shotgunSpread, shotgunSpread);
                Quaternion offset = Quaternion.Euler(x, y, 0);
                for (int i = 0; i < shotgunPelletAmount; i++)
                {
                    BulletControll newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.speed = bulletSpeed;
                }
                shotCounter = 0;
            }
                
        }
    }
}
