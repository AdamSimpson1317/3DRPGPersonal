using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("water");
            gameObject.GetComponentInParent<ThirdPersonMovement>().speed = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("no water");
            gameObject.GetComponentInParent<ThirdPersonMovement>().speed = 6;
        }
    }
}
