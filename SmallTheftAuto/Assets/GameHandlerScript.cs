using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandlerScript : MonoBehaviour
{
    
    void Start()
    {
        print(PlayerPrefs.GetFloat("Health"));
        print(PlayerPrefs.GetInt("Money"));
    }
}
