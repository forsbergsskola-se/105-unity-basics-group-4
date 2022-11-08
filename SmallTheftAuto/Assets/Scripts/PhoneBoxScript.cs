using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneBoxScript : MonoBehaviour
{
    public Transform player;
    public int phoneDistance;
    public GameObject buttonHolder;

    private string questName;
    void Start()
    {
        buttonHolder.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < phoneDistance && Input.GetKeyDown(KeyCode.F))
        {
              //interaction logic here.
              GetQuest();
        }
    }

    void GetQuest()
    {
        buttonHolder.SetActive(true);
        int random = Random.Range(1, 4);

    }

    public void SelectQuest(Button button)
    {
        buttonHolder.SetActive(false);
        button.GetComponentInChildren<TMP_Text>().SetText($""); 
    }

}
