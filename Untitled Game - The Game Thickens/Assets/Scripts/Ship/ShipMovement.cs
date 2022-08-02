using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipMovement : MonoBehaviour
{
    public GameObject shipPrompt;
    public GameObject player;
    public bool inShip;
    public bool shipControl;
    GameObject shipCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipPrompt.SetActive(true);
            inShip = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipPrompt.SetActive(false);
            inShip = false;
        }
    }

    private void Update()
    {
        //Should switch camera to ship and allow for ship controls
        if(Input.GetKeyDown(KeyCode.E) && inShip)
        {
            if (!shipControl)
            {
                shipCam.SetActive(true);
                player.SetActive(false);
                shipControl = true;
                player.transform.parent = gameObject.transform;
            }
            else
            {
                shipCam.SetActive(false);
                player.SetActive(true);
                shipControl = false;
                player.transform.parent = null;
            }
            
        }
    }
}
