using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float smoothSpeed;
    private Vector3 velocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var position = player.transform.position;
        Vector3 desiredPosition = position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
