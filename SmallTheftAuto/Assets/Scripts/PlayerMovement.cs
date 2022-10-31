using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float offset;
    public Camera mainCamera;
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
    }
}
