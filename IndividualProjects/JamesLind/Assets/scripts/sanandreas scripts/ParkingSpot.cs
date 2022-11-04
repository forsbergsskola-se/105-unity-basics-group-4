using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
   public bool hasCar;
   public GameObject CarPreFab;
   private void Start()
   {
      if (hasCar)
      {
         Instantiate(CarPreFab,transform.position + Vector3.up, quaternion.identity);
         hasCar = false;
      }
   }
}
