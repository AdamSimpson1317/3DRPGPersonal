using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public Achievement[] achievements;
    public GameObject[] achievementPanes;
    public PlayerStats ps;

    //Popup UI
    public GameObject achievementPanel;
    public TextMeshProUGUI achievementTitle;
    public TextMeshProUGUI achievementDesc;
    public Image achievementImage;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].requirements[0] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //REMOVE
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateGold();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdateKills();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            UpdateQuest();
        }
    }

    public void UpdateGold()
    {
        if (!achievements[0].earned)
        {
            Debug.Log(achievements[0].requirements[0].ToString());
            achievements[0].requirements[0] = ps.lifetimeGold;
        }
    }

    public void UpdateKills()
    {
        if (!achievements[1].earned)
        {
            achievements[1].requirements[0] = ps.totalKills;
        }
    }

    public void UpdateQuest()
    {
        if (!achievements[2].earned)
        {
            achievements[2].requirements[0] = ps.questsCompleted;
        }
    }

    public void UpdateGoldUI()
    {
        if (!achievements[0].earned)
        {
            achievementPanes[0].GetComponent<AchievementPane>().UpdateProgress();
            

        }
    }

    public void UpdateKillsUI()
    {
        if (!achievements[1].earned)
        {
            achievementPanes[1].GetComponent<AchievementPane>().UpdateProgress();
            
        }
    }

    public void UpdateQuestUI()
    {
        if (!achievements[2].earned)
        {
            achievementPanes[2].GetComponent<AchievementPane>().UpdateProgress();
            

        }
    }

    public void CheckGold()
    {
        Debug.Log(achievements[0].requirements[0].ToString());
        if (achievements[0].CheckRequirements())
        {
            
            //Pop achievement
            achievementTitle.text = achievements[0].title;
            achievementDesc.text = achievements[0].description;
            achievementImage.sprite = achievements[0].image;
            achievementPanes[0].GetComponent<AchievementPane>().Done();
            StartCoroutine(AchievementPop());
        }
    }

    public void CheckKills()
    {
        Debug.Log(achievements[1].requirements[0].ToString());
        if (achievements[1].CheckRequirements())
        {
            
            //Pop achievement
            achievementTitle.text = achievements[1].title;
            achievementDesc.text = achievements[1].description;
            achievementImage.sprite = achievements[1].image;
            achievementPanes[1].GetComponent<AchievementPane>().Done();
            StartCoroutine(AchievementPop());
        }
    }

    public void CheckQuest()
    {
        Debug.Log(achievements[2].requirements[0].ToString());
        if (achievements[2].CheckRequirements())
        {
            
            //Pop achievement
            achievementTitle.text = achievements[2].title;
            achievementDesc.text = achievements[2].description;
            achievementImage.sprite = achievements[2].image;
            achievementPanes[2].GetComponent<AchievementPane>().Done();
            StartCoroutine(AchievementPop());
        }
    }

    public IEnumerator AchievementPop()
    {
        achievementPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        achievementPanel.SetActive(false);
    }
}
