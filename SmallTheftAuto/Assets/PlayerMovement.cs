using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0; // VSync must be disabled
        Debug.Log(Application.targetFrameRate);
        Application.targetFrameRate = 60;
    }


// Update is called once per frame
    void Update()
    {
        // only, if the W-Key is currently pressed...
        if (Input.GetKey(KeyCode.W))
        {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Translate(0f, 0.00f, 30f*Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0f, 0.00f, 45f*Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Translate(0f, 0.00f, -30f*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Rotate(0f, -42f*Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Rotate(0f, 42f*Time.deltaTime, 0f);
        }
    }
}