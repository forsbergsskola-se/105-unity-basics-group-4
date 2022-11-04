using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Tower's ruined, you lose.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
