using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{       
    public GameObject player;
    public CarMovement carMovement;
    public PlayerMovement playerScript;



    void Start()
    {
        carMovement.enabled = false;
    }

    #region AwesomeUltraUsefullMethodsThatAre100%Efficient
    
    

    public void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public void LeaveCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }

    #endregion
    
    void Update()
    {
        if (playerScript.EnterCarButtonPressed())
        {
            if (playerScript.PlayerIsInCar())
            {
                 playerScript.cars[playerScript.closestCar].LeaveCar();
            }
        }
        

    }
    
}
