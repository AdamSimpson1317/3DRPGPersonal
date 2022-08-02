using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public SwordAttack swordAttack;
    public Animator animator;

    public float health = 10f;
    public PlayerStats ps;
    public Player player;
    public Manager manager;


    public NavMeshAgent agent;

    public Transform playerTransform;

    public LayerMask isGround, isPlayer;

    public GameObject Sword;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public bool isAttacking;
    public GameObject interactSphere;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Speed", 1);
    }

    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), interactSphere.GetComponent<Collider>());
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(playerTransform);

        if (!alreadyAttacked)
        {
            //Attack code here
            if (animator.GetBool("IsAttacking") == false)
            {
                Sword.GetComponent<BoxCollider>().enabled = true;
                animator.SetBool("IsAttacking", true);
                player.DamagePlayer(1);
                StartCoroutine(AttackCooldown());
            }
            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        else
        {
            if (animator.GetBool("IsAttacking") == true)
            {
                animator.SetBool("IsAttacking", false);

            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    /*public bool IsObjectQuestItem;

    public Quest quest;

    public void QuestCollectible()
    {
        if (quest.isActive)
        {
            IsObjectQuestItem = true;
        }

    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Comparing");
            Damage(1);
        }
    }*/


    public void DamageEnemy(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //ps.totalKills += 1;
            ps.UpdateKillsStat();
            ps.CheckStats();
            player.quest.questGoal.EnemyKilled();
            manager.IsAmountReached();
            Destroy(gameObject);
        }
    }

    public IEnumerator AttackCooldown()
    {
        Debug.Log("Cooldown");

        isAttacking = true;

        //Waits one second
        yield return new WaitForSeconds(4);
        isAttacking = false;

    }

}
