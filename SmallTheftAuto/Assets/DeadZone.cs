using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("The tower collapsed. Game over! (You suck.)");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
