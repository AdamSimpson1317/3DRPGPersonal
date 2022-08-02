using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 20;
    public int experience = 0;
    public int gold = 0;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;

    public Quest quest;

    public GameObject spawnPoint;

    private void Update()
    {
        healthText.text = health.ToString();
        experienceText.text = experience.ToString();
        goldText.text = gold.ToString();
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            healthText.text = health.ToString();
            gameObject.transform.position = spawnPoint.transform.position;
            //gameObject.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            health = 20;
            if (gold > 150)
            {
                gold -= 150;
            }
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
