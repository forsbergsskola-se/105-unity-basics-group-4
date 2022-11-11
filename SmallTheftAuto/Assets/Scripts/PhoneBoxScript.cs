using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class PhoneBoxScript : MonoBehaviour
{
    public Transform player;
    public int phoneDistance;
    public GameObject buttonHolder;
    public TMP_Text activeQuestUI;
    public Quest quest;
    public Quest[] displayQuest = new Quest[3];
    public PlayerStats playerStats;

    private string questName;
    public bool HasNoActiveQuest => quest?.ClearConditon() != false;
    private TMP_Text[] buttonDisplay;

    void Start()
    {
        buttonHolder.SetActive(false);
        buttonDisplay = buttonHolder.GetComponentsInChildren<TMP_Text>();
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < phoneDistance && Input.GetKeyDown(KeyCode.F))
        {
              //interaction logic here.
              buttonHolder.SetActive(true);
              if (HasNoActiveQuest)
              {
                  for (int i = 0; i < buttonDisplay.Length; i++)
                  {
                      displayQuest[i] = GetQuest();
                      buttonDisplay[i].SetText(displayQuest[i].name);
                  }
                  
              }
              else
              {
                  for (int i = 0; i < buttonDisplay.Length; i++)
                  {
                      buttonDisplay[i].SetText("Already on a quest!");
                  }
              }

        }

        if (quest?.ClearConditon() == true)
        {
            //Logic when quest is completed. rewards,xp,money.etc
            playerStats.money += quest.reward;
            quest = null;
        }
    }

    Quest GetQuest()
    { 
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            return new CrashCarQuest();
        }
        if (random == 2)
        {
            return new KillingQuest();
        }
        if (random == 3)
        {
            return new CrashCarQuest();

        }
        if (random == 4)
        {
            return new KillingQuest();

        }




        return null;

    }

    public void SelectQuest(int button)
    {
        buttonHolder.SetActive(false);
        if (HasNoActiveQuest)
        {
            quest = displayQuest[button];
            activeQuestUI.SetText(quest.name);
        }
        
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
    int victims;


    public KillingQuest()
    {
        victims = Random.Range(3, 10);
        reward = 5*victims;
        name = $"Kill {victims} people to earn {reward} money.";
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

public class CrashCarQuest : Quest, IClearable
{
    public PlayerStats playerStats;
    private int crashAmount;

    public CrashCarQuest()
    {
        crashAmount = Random.Range(1, 5);
        reward = 10 * crashAmount;
        name = $"Crash {crashAmount} cars to earn {reward} money";
        playerStats = Object.FindObjectOfType<PlayerStats>();
    }
    
    public override bool ClearConditon()
    {
        if (playerStats.CarsDestroyed >= crashAmount)
        {
            playerStats.CarsDestroyed = 0;
            return true;
        }

        return false;
    }
}

