using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorParameter : MonoBehaviour
{
    public Animator animator;
    public string parameterName;

    public void SetParameter(bool value)
    {
        animator.SetBool(parameterName, value);
    }
}

