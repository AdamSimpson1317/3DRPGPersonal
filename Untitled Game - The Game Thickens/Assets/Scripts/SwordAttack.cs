using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject player;
    public bool IsAttacking = false;
    public GameObject enemyAttacked;
    public string ObjectTag;
    public bool CanInteract = false;

    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Comparing");
            //CanInteract = true;
            ObjectTag = other.gameObject.tag;
            enemyAttacked = other.gameObject;
        }
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("Player");
        if (ObjectTag == "Enemy" && !IsAttacking)
        {
            Debug.Log("Attacked");
            IsAttacking = true;
            //SwordHit();
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Comparing");
            //CanInteract = true;
            ObjectTag = other.gameObject.tag;
            enemyAttacked = other.gameObject;
        }
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("Player");
        if (ObjectTag == "Enemy" && !IsAttacking)
        {
            Debug.Log("Attacked");
            IsAttacking = true;
            SwordHit();
        }
    }

    public IEnumerator SwordHit()
    {
        Debug.Log("SwordHit");
        //enemyAttacked.GetComponent<Enemy>().Health();
        //Waits one second
        yield return new WaitForSeconds(1);
        IsAttacking = false;
        
    }*/
}
