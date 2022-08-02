using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public string questItem;
    public int experienceReward;
    public int goldReward;

    public QuestGoal questGoal;

    public PlayerStats ps;

    public void Complete()
    {
        isActive = false;
        //ps.lifetimeGold += goldReward;
        //ps.questsCompleted += 1;
        ps.UpdateGoldStat(50);
        ps.UpdateQuestStat();
        ps.CheckStats();
        Debug.Log("Quest Completed");
    }



}
