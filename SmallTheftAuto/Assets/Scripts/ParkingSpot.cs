using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParkingSpot : MonoBehaviour
{
    public bool hasCar;
    public Vehicle carPrefab;
    public GameObject player;
    public PlayerMovement playerScript;

    void Start()
    {
        if (hasCar)
        {
            var vehicle = Instantiate(carPrefab, transform.position, Quaternion.identity);
            vehicle.player = player;
            vehicle.playerScript = playerScript;
        }

        

    }

    
}
