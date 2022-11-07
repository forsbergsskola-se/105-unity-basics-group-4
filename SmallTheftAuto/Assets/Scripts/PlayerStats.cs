using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    
    public TMP_Text text; 
    int health = 100;

    private void Update()
    {
        text.SetText(Convert.ToString($"Health:{health}"));
}
}    