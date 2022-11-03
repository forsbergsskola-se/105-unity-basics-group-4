using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    
    public GameObject player;
    private CarMovementScript carMovement;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        carMovement = GetComponent<CarMovementScript>();
    }

    // Update is called once per frame
    public void Enter()
    {
        Driver driver = player.GetComponent<Driver>();
        driver.gameObject.SetActive(false);
        carMovement.enabled = true;
    }

    public void Exit()
    {
        player.SetActive(true);
        player.transform.position = transform.position;
        carMovement.enabled = false;
    }
}
