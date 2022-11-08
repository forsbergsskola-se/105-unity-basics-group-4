using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, ITakeDamage
{

    public GameObject player;
    private CarMovementScript carMovement;
    public GameObject car;
    public int Health;
    public int MaxHealth;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
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

        if (Health <= 0)
        {
            
        }
    }
}