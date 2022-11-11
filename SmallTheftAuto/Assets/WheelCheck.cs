using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelCheck : MonoBehaviour
{
    public bool carIsGrounded;

    private void OnTriggerStay(Collider other)
    {
        carIsGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        carIsGrounded = false;
    }
}
