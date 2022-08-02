using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool IsObjectQuestItem;

    public Quest quest;

    public void QuestCollectible()
    {
        if(quest.isActive)
        {
            IsObjectQuestItem = true;
        }

    }


}
