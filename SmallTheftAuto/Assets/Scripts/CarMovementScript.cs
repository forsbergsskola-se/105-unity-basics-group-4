using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public Rigidbody rigidBody;
    public WheelCheck wheelCheck;
    public float downForce;

    void FixedUpdate()
    {

        if (wheelCheck.carIsGrounded)
        {
            if (rigidBody.velocity.magnitude < maxSpeed)
            {
                rigidBody.AddRelativeForce(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed));
            }
        }
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up*0);
            transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        }
    }
}
