using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject interactSphere;
    public bool cooldown = false;
    public GameObject enemyAttacked;
    public string objectTag;
    public bool canInteract = false;
    public bool inRange = false;
    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), interactSphere.GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Enemy") && player.GetComponent<ThirdPersonMovement>().isAttacking && !cooldown)
        {
            cooldown = true;
            enemyAttacked = other.gameObject;
            StartCoroutine(SwordHit());

            /*Debug.Log("Comparing");
            //CanInteract = true;
            objectTag = other.gameObject.tag;
            enemyAttacked = other.gameObject;
            //inRange = true;*/
        }

        /*if (objectTag == "Enemy" && player.GetComponent<ThirdPersonMovementOld>().isAttacking)
        {
            Debug.Log("Attacked");
            cooldown = true;
            StartCoroutine(SwordHit());
        }*/
    }

    public IEnumerator SwordHit()
    {
        Debug.Log("SwordHit");
        enemyAttacked.GetComponent<Enemy>().DamageEnemy(1);
        //Waits one second
        yield return new WaitForSeconds(0.5f);
        cooldown = false;

    }
}
