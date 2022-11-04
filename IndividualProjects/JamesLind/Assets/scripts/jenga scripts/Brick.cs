using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    void Start()
    {
        Debug.Log("game started.");
        Debug.Log("offsetting brick placements...");
        transform.position += transform.right * Random.Range(-.2f, .2f);
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        BrickCounter.countbrick();
    }
}
