using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float moveSpeed;
    public float sprintSpeed;
    public Camera cam;
    private float velocity;
    public float rotationSmoothness;
    private float yAngle;
    public GunController Gun;
    public Transform accualPosition;
    public Transform carPosition;
    public Vehicle vehicle;
    
    void Start()
    {
        accualPosition = transform;
    }

    void Update()
    {
        //Shooting controll
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Gun.isFiring = true;
        }
        else
        {
            Gun.isFiring = false;
        }
        
        if (vehicle.PlayerIsInCar())
        {
            accualPosition = carPosition;
        }
        else
        {
            accualPosition = transform;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        
        rb.velocity = new Vector3(x*moveSpeed*sprintSpeed, rb.velocity.y, z*moveSpeed*sprintSpeed);
        


        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 2.5f;
        }
        else
        {
            sprintSpeed = 1;
        }
        
        //Rotates the body towards its moving direction with a certain rotationSmoothness delay.

        if (rb.velocity.magnitude > 0)
        {
            Quaternion lookAtRotation = Quaternion.LookRotation(rb.velocity);
            yAngle = Mathf.SmoothDampAngle(yAngle, lookAtRotation.eulerAngles.y, ref velocity, rotationSmoothness, float.PositiveInfinity, Time.fixedDeltaTime);
            rb.rotation = Quaternion.Euler(0, yAngle, 0);
        }

        


    }
}
