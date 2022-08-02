using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    //public GameObject player;
    public bool CanInteract = false;
    public bool IsQuestItem = false;
    public string ObjectTag;
    public GameObject InteractibleObject;

    public QuestGiver questGiver;
    public Player player;
    public Manager manager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something");
        Debug.Log(other.tag);
        if (!other.gameObject.CompareTag("Ground")&&!other.gameObject.CompareTag("Weapon")&&!other.gameObject.CompareTag("Player"))
        {
            CanInteract = true;
            ObjectTag = other.gameObject.tag;
            InteractibleObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CanInteract = false;
    }

    private void Update()
    {
        if (CanInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ObjectTag == "Collectible")
                {
                    IsQuestItem = InteractibleObject.GetComponent<Collectible>().IsObjectQuestItem;
                    if (IsQuestItem)
                    {
                        Debug.Log("E");
                        questGiver.quest.questGoal.ItemCollected();
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
                        InteractibleObject.SetActive(false);
                        CanInteract = false;

                    }
                }
                else if(ObjectTag == "Ship")
                {
                    //Get On ship
                }
                else if(ObjectTag == "QuestGiver")
                {
                    questGiver = InteractibleObject.GetComponent<QuestGiver>();
                    if (!questGiver.quest.isActive)
                    {
                        Debug.Log("Quest Accepted");
                        InteractibleObject.GetComponent<QuestGiver>().AcceptQuest();
                        manager.questGiver = questGiver;
                    }
                }
            }
        }
    }
}
