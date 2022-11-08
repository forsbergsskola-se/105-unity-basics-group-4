using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float firetimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfdestruct());
    }

    IEnumerator selfdestruct()
    {
        yield return new WaitForSeconds(firetimer);
        Destroy(gameObject);
    }
    // Update is called once per frame
}
