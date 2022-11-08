using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }
    
    void Update()
    {
        bool walkForward = GetComponent<Rigidbody>().velocity.magnitude > 0.3;
        animator.SetBool("isWalking", walkForward);
        
        bool runForward = GetComponent<Rigidbody>().velocity.magnitude > 0.5;
        animator.SetBool("isRunning", runForward);
    }
}
