using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour, ITakeDamage
{
    
    public TMP_Text text; 
    int health = 100;
    public int CarsDestroyed;

    private void Update()
    {
        text.SetText(Convert.ToString($"Health:{health}"));
}

    public void takedamage(int damagedealt)
    {
        health = -damagedealt;
    }

    public void CarDestroyed()
    {
        CarsDestroyed++;
    }
}    