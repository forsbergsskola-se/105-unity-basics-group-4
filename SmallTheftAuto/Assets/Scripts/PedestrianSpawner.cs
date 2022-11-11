using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject pedestrianPrefab;
    public int maxPedestrians;
    private int _currentPedestrians;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPedestrians < maxPedestrians)
        {
            _currentPedestrians++;
            Instantiate(pedestrianPrefab, new Vector3(Random.Range(-100,100), 0, Random.Range(-100,100)), quaternion.identity);
        }
    }
}
