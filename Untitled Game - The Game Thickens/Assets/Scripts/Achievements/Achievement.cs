using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Achievement
{
    public string title;
    public Sprite image;
    public string description;
    public bool earned;
    public int[] requirements = new int[2];

    public bool CheckRequirements()
    {
        if(requirements[0] >= requirements[1] && !earned)
        {
            earned = true;
            return true;
        }
        else
        {
            return false;
        }
    }

}
