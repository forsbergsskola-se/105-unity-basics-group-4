using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Rigidbody rb;
    public static bool boom;
    void Start()
    {
        transform.position += Vector3.right * Random.Range(-.1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (boom)
        {
            boom = false;
            rb.AddForce(30,30,30);

        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Plane plane = new Plane(Vector3.up, Vector3.up * eventData.pointerPressRaycast.worldPosition.y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            transform.position = ray.GetPoint(distance);
        }

        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        if (Random.Range(0, 10) == 9)
        {
            boom = true;
            
            Debug.Log("BRUH");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
