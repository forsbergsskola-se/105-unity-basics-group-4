using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject objectFollow;
    public GameObject player;
    public Vector3 offset;
    public float smoothSpeed;
    private Vector3 velocity;

    private Vector3 _carZoom;
    public float carZoom;

    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var position = objectFollow.transform.position;
        Vector3 desiredPosition = position + offset + _carZoom;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            objectFollow = FindObjectOfType<CarMovementScript>().gameObject;
            _carZoom = new Vector3(0, carZoom, 0);

        }
        else
        {
            objectFollow = FindObjectOfType<PlayerMovement>().GameObject();
            _carZoom = new Vector3(0, 0, 0);

        }
    }
}
