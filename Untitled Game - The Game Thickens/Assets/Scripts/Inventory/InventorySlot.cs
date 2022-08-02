using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;
    public string itemName;
    public TextMeshProUGUI stackText;
    public int stackQty;
    public int stackLimit;
    public bool free = true;

    private void Start()
    {
        stackText.text = "";
    }

    public void AddToSlot(int qty, ItemScriptableObject item)
    {
        //Add to stack
        stackQty += qty;
        slotImage.sprite = item.itemImage;
        itemName = item.itemName;
        stackText.text = stackQty.ToString();
        free = false;
    }

    public void RemoveFromSlot()
    {
        //Remove from stack
        if(stackQty == 0)
        {
            free = true;
        }
    }
}
