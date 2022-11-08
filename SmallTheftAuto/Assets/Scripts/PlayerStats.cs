using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour, ITakeDamage
{
    
    public TMP_Text text;
    public int maxhealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int money = 9999;
    public int CarsDestroyed;

    public void Start()
    {
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    private void Update()
    {
        text.SetText(Convert.ToString($"${money}"));
        if (Input.GetKeyDown(KeyCode.H))
        {
            takedamage(10);
        }
    }
    public void takedamage(int damagedealt)
    {
        currentHealth -= damagedealt;
        healthBar.SetHealth(currentHealth);
    }

    public void CarDestroyed()
    {
        CarsDestroyed++;
    }
}    