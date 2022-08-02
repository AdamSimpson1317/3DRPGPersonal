using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipCol : MonoBehaviour
{
    public bool nearShip;
    public bool shipControl;
    public GameObject shipPrompt;
    public TextMeshProUGUI promptText;
    public GameObject ocean;
    public GameObject oceanNet;
    public GameObject player;
    public GameObject shipCam;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(ocean.GetComponent<Collider>(), GetComponent<MeshCollider>());
        Physics.IgnoreCollision(oceanNet.GetComponent<Collider>(), GetComponent<MeshCollider>());
        //shipCam = gameObject.transform.parent.gameObject.GetComponent<>()
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TO PLAYER SCRIPT
        //Should switch camera to ship and allow for ship controls
        if (Input.GetKeyDown(KeyCode.E) && nearShip)
        {
            if (!shipControl)
            {
                shipCam.SetActive(true);
                promptText.text = "Press [E] to Exit";
                player.SetActive(false);
                shipControl = true;
                player.transform.parent = gameObject.transform;
                transform.parent.GetComponent<Ship>().playerControlled = true;

            }
            else
            {
                shipCam.SetActive(false);
                shipPrompt.SetActive(false);
                nearShip = false;
                player.SetActive(true);
                shipControl = false;
                player.transform.parent = null;
                transform.parent.GetComponent<Ship>().playerControlled = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.text = "Press [E] to Sail";
            shipPrompt.SetActive(true);
            nearShip = true;

            

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipPrompt.SetActive(false);
            nearShip = false;
        }
    }

}
