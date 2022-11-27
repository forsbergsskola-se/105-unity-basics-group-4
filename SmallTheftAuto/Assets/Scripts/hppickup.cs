using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hppickup : MonoBehaviour
{
    public GameObject controller;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (other.gameObject.CompareTag("Player"))
        {
            playerStats.currentHealth += 25;
            controller.BroadcastMessage("respawntimer");
            gameObject.SetActive(false);
        }
    }
}
