using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;
    //public Text questItem;

    public GameObject questPopup;
    public TextMeshProUGUI titleTextUI;
    public TextMeshProUGUI descriptionTextUI;
    public TextMeshProUGUI experienceTextUI;
    public TextMeshProUGUI goldTextUI;



    private void OnTriggerEnter(Collider other)
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString() + " XP";
        goldText.text = quest.goldReward.ToString();


    }

    private void OnTriggerExit(Collider other)
    {
        questWindow.SetActive(false);
    }
    public void AcceptQuest()
    {
        quest.isActive = true;
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        foreach(GameObject collectible in collectibles)
        {
            collectible.GetComponent<Collectible>().IsObjectQuestItem = true;
        }
        questWindow.SetActive(false);
        player.quest = quest;
        quest.questGoal.currentAmount = 0;

        questPopup.SetActive(true);
        titleTextUI.text = quest.title;
        descriptionTextUI.text = quest.description;
        experienceTextUI.text = quest.experienceReward.ToString() + " XP";
        goldTextUI.text = quest.goldReward.ToString();
    }

}
