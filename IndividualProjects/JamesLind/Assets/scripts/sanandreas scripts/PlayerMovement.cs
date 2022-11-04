using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour //note: i may have gone a bit too far in a couple of places.
{
    //setup for addforce functions instead of translates:
    private Rigidbody thisbody;
    //todo: set final limits and make thrust, maxjumpspeed, jumptimer private
    public float thrust; 
    public float maxjumpspeed;
    public float maxspeed;
    public float jumptimer;
    public bool isgrounded;

    private void Start() { thisbody = GetComponent<Rigidbody>(); }
    //setup end
    
    //collision/'grounded' detection
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
    void Update()
    {
        if (isgrounded)//wrapping full movement in isgrounded - because you can't alter movement midair!
        {
            //movement logic:
            if (Input.GetButton("Horizontal"))
            {
                thisbody.AddForce(transform.right * (thrust * Input.GetAxis("Horizontal"))); 
                //.right due to the map being 'sideways'.
            }

            if (Input.GetButton("Rotation"))
            {
                transform.Rotate(0f, 0.15f*Input.GetAxis("Rotation"), 0f);
            }
            
            //Jump logic:
            if (Input.GetButtonDown("Jump"))
            {
                while (jumptimer < 1)
                {
                    thisbody.AddForce(transform.up * thrust);
                    jumptimer += Time.fixedDeltaTime;
                }
                jumptimer = 0;
            }
        }
        //speed limits:
        //bug: following currently gimps jumping and moving at the same time, limiting y-axis move to magnitude. not sure how to fix.
        if (thisbody.velocity.y > maxjumpspeed) { thisbody.velocity = thisbody.velocity.normalized * maxjumpspeed; } //for jumps
        if (thisbody.velocity.magnitude > maxspeed) { thisbody.velocity = thisbody.velocity.normalized * maxspeed; } //for walking
    }
}
