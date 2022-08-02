using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Panel;
    public float Health = 10f;
    //public float HealthBarValue = 1;
    //public float volume = 1f;
    //[SerializeField] AudioClip clip;

    //public Image HealthBarImage;
    //Changes health bar colour dependent on how much health the player has left.
    /*public void SetHealthBar(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount <= 0.2f)
        {
            SetHealthBarColour(Color.red);
        }
        else if (HealthBarImage.fillAmount <= 0.4f)
        {
            SetHealthBarColour(Color.yellow);
        }
        else
        {
            SetHealthBarColour(Color.green);
        }
    }

    //Gets how far the health is already filled.
    public float GetHealthValue()
    {
        return HealthBarImage.fillAmount;
    }

    //Sets the colour of the bar.
    public void SetHealthBarColour(Color healthColour)
    {
        HealthBarImage.color = healthColour;
    }

    private void Start()
    {
        SetHealthBar(1.0f);
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Health = Health - 1;
        }
        if (Health <= 0)
        {
            Destroy(Player);
            //Panel.SetActive(true);
        }
    }

    //Destroys player once health hits 0.
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            Health = Health - 1;
            //AudioSource.PlayClipAtPoint(clip, Player.transform.position, volume);
            Destroy(collision.gameObject);
            HealthBarValue = Health / 10f;
            SetHealthBar(HealthBarValue);
        }

        if (Health <= 0)
        {
            Destroy(Player);
            Panel.SetActive(true);
        }
    }*/
}
