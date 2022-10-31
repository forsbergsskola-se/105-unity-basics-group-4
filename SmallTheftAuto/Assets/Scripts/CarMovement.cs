using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject wheel;
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        
        transform.Translate(0,0,move * 0.1f);
        
        transform.Rotate(0, rotation,0);

        wheel.transform.Rotate(100,0,0);
        
        
        
    }
}
