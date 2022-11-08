using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public PhoneBoxScript phoneBoxScript;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
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
