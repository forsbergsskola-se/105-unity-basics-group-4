using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jenga : MonoBehaviour
{
    private int _brickCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BrickRemoved()
    {
        _brickCounter++;
        Debug.Log($"{_brickCounter} bricks have been removed");
    }
}
