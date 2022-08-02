using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public Inventory playerInventory;
    public Player player;

    public ItemScriptableObject item;
    public Image itemImg;
    public TextMeshProUGUI itemPrice;

    public void UpdateSlot(ItemScriptableObject newItem)
    {
        Debug.Log(newItem.itemName);
        Debug.Log(newItem.buyPrice);
        item = newItem;
        itemImg.sprite = newItem.itemImage;
        itemPrice.text = newItem.buyPrice.ToString();
    }

    public void Buy()
    {
        //Check for player gold
        if (player.gold >= item.buyPrice)
        {
            //Deduct player gold
            player.gold -= item.buyPrice;
            //Buy item if player has enough gold
            playerInventory.AddToInventory(1, item);
        }
    }
}
