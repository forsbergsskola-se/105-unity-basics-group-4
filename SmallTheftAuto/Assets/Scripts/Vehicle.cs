using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Vehicle : MonoBehaviour, ITakeDamage
{

    public GameObject player;
    private PlayerStats playerstats;
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

    bool PlayerIsInCar()
    {
        if (player.activeInHierarchy)
        {
            return false;
        }

        return true;
    }

    void LeaveCar()
    {
        player.SetActive(true);
        player.transform.position = car.transform.position + new Vector3(2, 0, 0);
        carMovement.enabled = false;
    }
    //placed PlayerIsInCar and LeaveCar outside of EnterCarButtonPressed due to access need in explosion script.
    //entering/exiting car still works as normal - if not, check move of functions for bugs.
    
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

        PlayerIsInCar();

        void EnterCar()
        {
            player.SetActive(false);
            carMovement.enabled = true;
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

    void damagetesting() //todo: remove in final product
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
        yield return new WaitForSeconds(1f);

        if (PlayerIsInCar())    //checks if player is outside the car or not.
        {
            LeaveCar();         //kicks player out of car to prevent player model being destroyed. for now.
            playerstats.takedamage(200);    //deals a bunch of damage to the player if they're in car
        } 
        
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