using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shopkeeper : MonoBehaviour
{
    public ItemScriptableObject[] sellerItems;
    public ShopSlot[] sellSlots;

    public bool nearShopkeeper;
    public bool inShop;
    public GameObject shopWindow;
    public GameObject shopPrompt;
    public TextMeshProUGUI promptText;

    private void Start()
    {
        for (int i = 0; i < sellerItems.Length; i++)
        {
            Debug.Log(sellerItems[i].name);
            sellSlots[i].UpdateSlot(sellerItems[i]);
        }
    }

    private void Update()
    {
        if(nearShopkeeper && Input.GetKeyDown(KeyCode.E))
        {
            if (!inShop)
            {
                inShop = true;
                shopPrompt.SetActive(false);
                shopWindow.SetActive(true);
            }
            else
            {
                inShop = false;
                shopWindow.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nearShopkeeper = true;
        promptText.text = "Press [E] to Shop";
        shopPrompt.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        nearShopkeeper = false;
        shopPrompt.SetActive(false);
    }
}
