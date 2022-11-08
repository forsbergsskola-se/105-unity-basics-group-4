using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveScript : MonoBehaviour
{public PhoneBoxScript phoneBoxScript;
 
     void Start()
     {
         phoneBoxScript = FindObjectOfType<PhoneBoxScript>();
     }
 
     private void OnTriggerStay(Collider collision)
     {
         if (collision.CompareTag("Player") && phoneBoxScript.quest == null ||collision.CompareTag("Player") && phoneBoxScript.quest.ClearConditon() )
         {
             Save();
             print("colliding");
 
         }
     }
    

    void Save()
    {
        PlayerPrefs.SetInt("Money", 20); //Replace 20 with players money
        PlayerPrefs.SetFloat("Health", 20); //Replace 20 with players health
    }
}
