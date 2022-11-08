using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PhoneBoxScript : MonoBehaviour
{
    public Transform player;
    public int phoneDistance;
    public GameObject buttonHolder;
    public Quest quest;

    private string questName;
    public bool HasNoActiveQuest => quest?.ClearConditon() != false;
    void Start()
    {
        buttonHolder.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < phoneDistance && Input.GetKeyDown(KeyCode.F))
        {
              //interaction logic here.
              buttonHolder.SetActive(true);
              if (HasNoActiveQuest)
              {
                  quest = GetQuest();
                  TMP_Text[] buttonDisplay = buttonHolder.GetComponentsInChildren<TMP_Text>();
                  buttonDisplay[0].SetText(quest.name);
              }
              
        }

        if (quest.ClearConditon())
        {
            //Logic when quest is completed. rewards,xp,money.etc
        }
    }

    Quest GetQuest()
    { 
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            return new KillingQuest();
        }
        if (random == 2)
        {
            return new KillingQuest();
        }
        if (random == 3)
        {
            return new KillingQuest();

        }
        if (random == 4)
        {
            return new KillingQuest();

        }




        return null;

    }

    public void SelectQuest(Button button)
    {
        buttonHolder.SetActive(false);
    }

}
public interface IClearable
{
    public bool ClearConditon();
}

public abstract class Quest : IClearable
{
    public string name;
    public int reward = 2;
    void KillingQuest()
    {
        
    }


    public abstract bool ClearConditon();
}

public class KillingQuest : Quest, IClearable
{
    public int victims = 3;


    public KillingQuest()
    {
        name = $"Kill {victims} people to earn {reward} money.";
        reward = 49;
    }
    
    public override bool ClearConditon()
    {
        if (victims == 4)
        {
            return true;
        }

        return false;
    }
}

