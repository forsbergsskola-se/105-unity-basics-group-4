using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hprespawner : MonoBehaviour
{
    public GameObject hppickup;
    public IEnumerator respawntimer()
    {
        yield return new WaitForSeconds(5);
        hppickup.SetActive(true);
    }
}
    