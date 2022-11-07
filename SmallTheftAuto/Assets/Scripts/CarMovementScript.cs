using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public Rigidbody rigidBody;
    public bool isgrounded;
    private void OnCollisionEnter()
    {
        isgrounded = true;
    }
    private void OnCollisionStay()
    {
        isgrounded = true;
    }
    private void OnCollisionExit()
    {
        isgrounded = false;
    }

    void FixedUpdate()
    {
        if (isgrounded)
        {
            if (rigidBody.velocity.magnitude < maxSpeed)
            {
                rigidBody.AddRelativeForce(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed));
            }

            transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
        }
    }
}
