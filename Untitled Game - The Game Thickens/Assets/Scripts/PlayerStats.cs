using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int lifetimeGold;
    public int totalKills;
    public int questsCompleted;
    public AchievementManager achievementMan;

    public void UpdateGoldStat(int gold)
    {
        lifetimeGold += gold;
        achievementMan.UpdateGold();

    }

    public void UpdateKillsStat()
    {
        totalKills += 1;
        achievementMan.UpdateKills();

    }

    public void UpdateQuestStat()
    {
        questsCompleted += 1;
        achievementMan.UpdateQuest();

    }

    public void CheckStats()
    {
        achievementMan.CheckGold();
        achievementMan.CheckKills();
        achievementMan.CheckQuest();
    }

}
