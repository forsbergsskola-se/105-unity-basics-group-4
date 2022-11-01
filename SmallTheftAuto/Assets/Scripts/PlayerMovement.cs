using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float offset;
    public Camera mainCamera;
    public Vehicle vehicle;
    public Vehicle[] cars;
    public int closestCar = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        
        transform.Translate(0,0,move * 0.1f);
        
        transform.Rotate(0, rotation,0);

       
        
        
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Vector3 position = mainCamera.transform.localPosition;
            position.z = 6;
            mainCamera.transform.localPosition = position;
            Vector3 eulerAngles = mainCamera.transform.localRotation.eulerAngles;
            eulerAngles.y = 180;
            mainCamera.transform.localRotation = Quaternion.Euler(eulerAngles);
            
        }
        else
        {
            Vector3 position = mainCamera.transform.localPosition;
            position.z = -6;
            mainCamera.transform.localPosition = position;
            Vector3 eulerAngles = mainCamera.transform.localRotation.eulerAngles;
            eulerAngles.y = 0;
            mainCamera.transform.localRotation = Quaternion.Euler(eulerAngles);
        }
        
        
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                GetClosestCar().LeaveCar();
            }
            else
            {
                GetClosestCar().EnterCar();
            }
            
        }
        
    }
    
    
    public bool PlayerIsInCar()
    {
        
        if (gameObject.activeInHierarchy)
        {
            return false;
        }


        return true;
    }
    
    public bool EnterCarButtonPressed()
    {
        return Input.GetButtonDown("Input-Vehicle");
    } 
    
    public Vehicle GetClosestCar()
    {
        cars = FindObjectsOfType<Vehicle>();
        float minDistance = 2f;
        for (int i = 0; i < cars.Length ; i++)
        {
            if (Vector3.Distance(cars[i].gameObject.transform.position, transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(cars[i].gameObject.transform.position, transform.position);
                closestCar = i;
            }

           
        }
        if(Vector3.Distance(cars[closestCar].gameObject.transform.position, transform.position) < 2f)
            return cars[closestCar];
        return null;
    }
}
