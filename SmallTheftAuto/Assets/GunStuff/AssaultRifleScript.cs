    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AssaultRifleScript : MonoBehaviour
    {
        public PlayerMovement playermovement;
        public BulletControll bullet;
        public float bulletSpeed;
        public float timeBetweenShots;
        private float shotCounter;
        public Transform firePoint;
        public float burstFire;
        public float burstDelay;
        public float burstTimer;
        int daddy;
        void Start()
        {
            shotCounter = timeBetweenShots;
        }
        
        void Update()
        {
            shotCounter -= Time.deltaTime;
            if(playermovement.isFiring)
            {
                if (shotCounter <= 0)
                {
                    while (burstFire > daddy)
                    {
                        burstTimer += Time.deltaTime;
                        if (burstTimer > burstDelay)
                        {
                            daddy++;
                            burstTimer = 0;
                            BulletControll newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                            newBullet.speed = bulletSpeed;
                            print("GUNFIRED:D");
                        }
                    }
                    daddy = 0;
                }
            }
            else
            {
                shotCounter = 0;
            }
        }
        }


