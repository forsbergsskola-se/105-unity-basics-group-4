using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float firetimer;
    public bool playertriggering;
    public bool burningplayer;
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
    public void OnTriggerStay(Collider other)
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (other.gameObject.CompareTag("Player"))
        {
            playertriggering = true;
            if (!burningplayer) //ensures that only one instance of burningdamage is started and active.
            {
                StartCoroutine(Burningdamage(playerStats));
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playertriggering = false;
        }
    }

    IEnumerator Burningdamage(PlayerStats playertoburn)
    {
        burningplayer = true;
        while (playertriggering)
        {
            playertoburn.takedamage(10);
            yield return new WaitForSecondsRealtime(1f);
        }

        burningplayer = false;
    }
    // Update is called once per frame
}
