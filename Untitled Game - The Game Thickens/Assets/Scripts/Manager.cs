using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public QuestGiver questGiver;
    public Player player;
    public AudioSource audiosource;

    private void Start()
    {
        audiosource.Play();
    }
    public void IsAmountReached()
    {
        if (questGiver != null) {
            if (questGiver.quest.questGoal.IsReached())
            {
                GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
                foreach (GameObject collectible in collectibles)
                {
                    collectible.GetComponent<Collectible>().IsObjectQuestItem = false;
                }

                player.gold += player.quest.goldReward;
                player.experience += player.quest.experienceReward;
                questGiver.questPopup.SetActive(false);
                questGiver.quest.Complete();
            }
        }
    }
}
