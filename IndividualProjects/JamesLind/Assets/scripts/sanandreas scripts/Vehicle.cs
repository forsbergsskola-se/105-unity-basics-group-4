using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    public CarMovement carMovement;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (InCarCheck.NotInCar(player))
            {
                if (InCarCheck.closeenough(player, carMovement))
                {
                    InCarCheck.GetInLoser(player, carMovement);
                }
            }
            else if (InCarCheck.NotInCar(player) == false)
            {
                InCarCheck.GetOutLoser(player, carMovement);
            }
        }
    }
}