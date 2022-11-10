using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinimapScript: MonoBehaviour
{
    private GameObject objectFollow;
    public GameObject player;
    public Vector3 offset;
    private Vector3 velocity;
    
    void LateUpdate()
    {
        var position = objectFollow.transform.position;
        transform.position = position+offset;

    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            objectFollow = FindObjectOfType<CarMovementScript>().gameObject;

        }
        else
        {
            objectFollow = FindObjectOfType<PlayerMovement>().GameObject();

        }
    }
}