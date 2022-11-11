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
        public int burstFire;
        int daddy;
        
        IEnumerator Burst()
        {
            for (int i = 0; i < burstFire; i++)
            {
                BulletControll newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = bulletSpeed;
                yield return new WaitForSeconds(0.1f);
            }
           
        }

        
        void Update()
        {
            shotCounter += Time.deltaTime;
            if (playermovement.autoFire)
            {
                if (shotCounter >= timeBetweenShots)
                {
                    StartCoroutine(Burst());
                    shotCounter = 0;
                }
                
            }
        }
    }

                
            
        
        


