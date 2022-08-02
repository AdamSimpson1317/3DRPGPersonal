using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public Animator animator;

    public GameObject Sword;
    public GameObject interactSphere;

    public float speed = 6;
    public float sprintSpeed = 12;
    public float swimSpeed = 2;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;
    bool inOcean;
    bool cooldown;

    public bool isAttacking;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public LayerMask waterMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public GameObject achievementTab;
    public AchievementManager achievementMan;

    public GameObject ocean;

    public GameObject shipPrefab;
    public GameObject oceanRef;
    public GameObject oceanNetRef;
    public GameObject keyPromptRef;
    public GameObject previousShip;
    public GameObject shipCam;

    private void Start()
    {
        Physics.IgnoreCollision(ocean.GetComponent<Collider>(), controller);
        Physics.IgnoreCollision(interactSphere.GetComponent<Collider>(), controller);
    }
    void Update()
    {
        float tempSpeed = speed;
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        inOcean = Physics.CheckSphere(groundCheck.position, groundDistance, waterMask);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            achievementTab.SetActive(!achievementTab.activeInHierarchy);
            if (achievementTab.activeInHierarchy)
            {

                achievementMan.UpdateGoldUI();
                achievementMan.UpdateKillsUI();
                achievementMan.UpdateQuestUI();
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if(animator.GetBool("IsJumping") == true)
            {
                animator.SetBool("IsJumping", false);
            }
        }
        
        if (inOcean)
        {
            tempSpeed = swimSpeed;
            if (animator.GetBool("IsSwimming") == false)
            {
                animator.SetBool("IsSwimming", true);
            }
        }
        else
        {
            if (animator.GetBool("IsSwimming") == true)
            {
                animator.SetBool("IsSwimming", false);
            }
        }


        if (Input.GetButtonDown("Jump") && isGrounded && !inOcean)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            animator.SetBool("IsJumping", true);

        }
        /*else
        {
            animator.SetBool("IsJumping", false);
        }*/

        if (Input.GetButtonDown("Roll") && isGrounded && !inOcean)
        {
            animator.SetBool("IsRolling", true);

        }
        else
        {
            animator.SetBool("IsRolling", false);
        }


        if (Input.GetButton("Sprint") && !inOcean)
        {
            tempSpeed = sprintSpeed;
            if (animator.GetBool("IsSprinting") == false)
            {
                animator.SetBool("IsSprinting", true);
            }
        }
        else
        {
            if (animator.GetBool("IsSprinting") == true)
            {
                animator.SetBool("IsSprinting", false);
            }
        }

        if(Input.GetButtonDown("SwordAttack") && !isAttacking)
        {
            if (animator.GetBool("IsAttacking") == false)
            {
                Sword.GetComponent<BoxCollider>().enabled = true;
                animator.SetBool("IsAttacking", true);
                
                StartCoroutine(AttackCooldown());
            }
        }
        else
        {
            if (animator.GetBool("IsAttacking") == true)
            {
                animator.SetBool("IsAttacking", false);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(previousShip);
            GameObject newShip = Instantiate(shipPrefab, new Vector3(34,10,24), Quaternion.identity);
            newShip.GetComponentInChildren<ShipCol>().shipPrompt = keyPromptRef;
            newShip.GetComponentInChildren<ShipCol>().promptText = keyPromptRef.GetComponent<TextMeshProUGUI>();
            newShip.GetComponentInChildren<ShipCol>().ocean = oceanRef;
            newShip.GetComponentInChildren<ShipCol>().oceanNet = oceanNetRef;
            newShip.GetComponentInChildren<ShipCol>().player = gameObject;
            previousShip = newShip;
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * tempSpeed * Time.deltaTime);
            animator.SetFloat("Speed", tempSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    public IEnumerator AttackCooldown()
    {
        Debug.Log("Cooldown");

        isAttacking = true;

        //Waits one second
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;

    }

}
