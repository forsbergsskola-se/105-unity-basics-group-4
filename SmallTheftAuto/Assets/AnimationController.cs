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
        bool isWalking = animator.GetBool("isWalking");
        bool walkForward = Input.GetKey(KeyCode.W);

        if (!isWalking && walkForward)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !walkForward)
        {
            animator.SetBool("isWalking", false);
        }
    }
}
