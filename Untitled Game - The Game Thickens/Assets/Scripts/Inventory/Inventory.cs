using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySlot[] slots = new InventorySlot[20];
    public ItemScriptableObject testObj1;
    public ItemScriptableObject testObj2;

    public void AddToInventory(int qty, ItemScriptableObject item)
    {

        for (int i = 0; i < slots.Length; i++)
        {
            
            if ((slots[i].itemName.ToString().Equals(item.itemName.ToString()) && (slots[i].stackQty + qty) <= slots[i].stackLimit) || slots[i].free)
            {
                slots[i].AddToSlot(qty, item);
                break;
            }
            else if ((slots[i].stackQty + qty) > slots[i].stackLimit && (slots[i].stackQty != slots[i].stackLimit) && (slots[i].itemName.ToString().Equals(item.itemName.ToString())))
            {
                //Sort out overflow
                //check for overflow 
                // 8 + 4 > 10
                //int overflow = (slots[i].stackQty + qty) - slots[i].stackLimit;

                int preflow = slots[i].stackLimit - slots[i].stackQty;
                int overflow = qty - preflow;

                Debug.Log(preflow);
                Debug.Log(overflow);

                slots[i].AddToSlot(preflow, item);

                /*for (int j = i; j < slots.Length; j++)
                {
                    if ((slots[j].itemName.ToString().Equals(item.itemName.ToString()) && (slots[j].stackQty + overflow) <= slots[j].stackLimit) || slots[j].free)
                    {
                        slots[j].AddToSlot(overflow, item);
                        break;
                    }
                }*/
                AddToInventory(overflow, item);
                break;

            }
        }

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //slots[0].AddToSlot(1, testObj1);
            AddToInventory(4, testObj1);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //slots[1].AddToSlot(1, testObj2);
            AddToInventory(9, testObj2);
        }
    }
}
