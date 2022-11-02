using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float moveSpeed;
    public float sprintSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x*moveSpeed*sprintSpeed, rb.velocity.y, z*moveSpeed*sprintSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 2.5f;
        }
        else
        {
            sprintSpeed = 1;
        }
    }
}
