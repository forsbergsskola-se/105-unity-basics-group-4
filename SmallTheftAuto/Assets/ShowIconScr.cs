using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIconScr : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weaponIcon;

    void Update()
    {
        if (!weapon.activeInHierarchy)
        {
            weaponIcon.SetActive(false);
        }
        else
        {
            weaponIcon.SetActive(true);
        }
    }
}
