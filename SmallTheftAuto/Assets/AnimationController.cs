using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public PlayerMovement playerMovement;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    void Update()
    {
        bool walkForward = GetComponent<Rigidbody>().velocity.magnitude > 0.1;
        animator.SetBool("isWalking", walkForward);
        
        bool runForward = playerMovement.sprintSpeed > 1;
        animator.SetBool("isRunning", runForward);
    }
}
