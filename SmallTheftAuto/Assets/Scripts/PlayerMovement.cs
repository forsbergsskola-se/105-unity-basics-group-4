using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
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
}
