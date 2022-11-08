using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Vehicle : MonoBehaviour, ITakeDamage
{

    public GameObject player;
    public PlayerStats playerstats;
    private CarMovementScript carMovement;
    public GameObject car;
    public int Health;
    public int MaxHealth;
    public GameObject firefab;
    public GameObject explofab;
    private bool BurningDownRunning;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        playerstats = FindObjectOfType<PlayerStats>();
        carMovement = GetComponent<CarMovementScript>();
        Health = MaxHealth;
    }

    void Update()
    {
        EnterCarButtonPressed();
        damagetesting();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void EnterCarButtonPressed()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (PlayerIsInCar()) // Already in Car, so get out of car
                LeaveCar();
            else // Not in Car, get in
            if (Vector3.Distance(car.transform.position, player.transform.position) < 2)
                EnterCar();
        }

        bool PlayerIsInCar()
        {
            if (player.activeInHierarchy)
            {
                return false;
            }

            return true;
        }

        void EnterCar()
        {
            player.SetActive(false);
            carMovement.enabled = true;
        }

        void LeaveCar()
        {
            player.SetActive(true);
            player.transform.position = car.transform.position + new Vector3(2, 0, 0);
            carMovement.enabled = false;
        }


        // Update is called once per frame
        /*void Enter()
        {
            Driver driver = player.GetComponent<Driver>();
            driver.gameObject.SetActive(false);
            carMovement.enabled = true;
        }

        void Exit()
        {

            player.SetActive(true);
            player.transform.position = transform.position;
            carMovement.enabled = false;
        }*/
    }

    void damagetesting()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            takedamage(10);
        }
    }

    public void takedamage(int damagedealt)
    {
        Health -= damagedealt;
        if (Health <= 50&& !BurningDownRunning)
        {
            StartCoroutine(burningdown());
        }

        if (Health <= 0)
        {
            StartCoroutine(CarExplode());
        }
    }

    IEnumerator CarExplode()
    {
        BurningDownRunning = false;
        Instantiate(explofab, this.transform.position, quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(firefab, this.transform.position, quaternion.identity);
        Destroy(car);
        playerstats.CarDestroyed();
    }

    IEnumerator burningdown()
    {
        while (Health>0)
        {
            BurningDownRunning = true;
            yield return new WaitForSeconds(1f);
            takedamage(5);
            GameObject carfire = Instantiate(firefab, this.transform.position, quaternion.identity);
            carfire.transform.parent = gameObject.transform;
        }

        BurningDownRunning = false;
    }
}