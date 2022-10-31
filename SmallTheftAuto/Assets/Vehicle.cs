using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    public CarMovement carMovement;
    
    void Start()
    {
        carMovement.enabled = false;
    }

    #region AwesomeUltraUsefullMethodsThatAre100%Efficient

    bool EnterCarButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.F);
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
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }

    #endregion
    
    void Update()
    {
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                LeaveCar();
            }
            else
            {
                if(Vector3.Distance(player.transform.position,transform.position) < 2)
                {
                    EnterCar();
                }
            }
            
        }
        
    }
}
