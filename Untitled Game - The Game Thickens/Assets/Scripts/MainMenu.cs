using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject cam;
    public GameObject inventory;
    public GameObject menuPanel;

    public void StartGame()
    {
        gameObject.SetActive(false);
        cam.SetActive(false);
        inventory.SetActive(true);
        
    }
}
