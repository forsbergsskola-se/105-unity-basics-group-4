using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.Exit(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
