using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPane : MonoBehaviour
{
    public TextMeshProUGUI achievementTitle;
    public TextMeshProUGUI achievementDesc;
    public Image achievementImage;
    public TextMeshProUGUI achievementProgress;

    public AchievementManager achievementManager;
    private Achievement achievement;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        achievement = achievementManager.achievements[index];
        achievementTitle.text = achievement.title;
        achievementDesc.text = achievement.description;
        achievementImage.sprite = achievement.image;
        //achievementProgress.text = achievement.requirements[0].ToString() + " of " + achievement.requirements[1].ToString();
        UpdateProgress();
    }

    public void UpdateProgress()
    {
        achievementProgress.text = achievement.requirements[0].ToString() + " of " + achievement.requirements[1].ToString();
    }

    public void Done()
    {
        achievementProgress.text = "Done";
        gameObject.GetComponent<Image>().color = Color.green;
    }
}
