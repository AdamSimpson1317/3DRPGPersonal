using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int buyPrice;
    public int sellPrice;
}


