using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody rb;
    public int forward;
    public int forceUp;
    public float viscosity;

    public bool playerControlled;
    public bool aiControlled;
    [SerializeField] float rotSpeed;

    public float stability = 0.3f;
    public float speed = 2.0f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //Sideways stability
        Vector3 predictedUp = Quaternion.AngleAxis(
         rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
         rb.angularVelocity
     ) * transform.up;
        Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
        torqueVector = Vector3.Project(torqueVector, transform.forward);
        rb.AddTorque(torqueVector * speed * speed);

    }

    // Update is called once per frame
    void Update()
    {

        if (playerControlled)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //Vector3 force = new Vector3(0, 0, forward);
                //Vector3 force = transform.forward * Time.deltaTime * 10;
                rb.AddForce(transform.forward * -forward);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, rotSpeed, 0.0f, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, -rotSpeed, 0.0f, Space.World);
            }
        }
        else if (aiControlled)
        {
            Vector3 force = new Vector3(0, 0, -0.5f);
            rb.AddForce(force);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Water"))
        {
            rb = GetComponent<Rigidbody>();

            //get normals
            //avg normals
            //put with force up
            
            //Debug.Log(other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position));



            Vector3 force = new Vector3(0, forceUp, 0);


            rb.AddForce(force);
            rb.AddForce(rb.velocity * -1 * viscosity);
        }

    }
}
