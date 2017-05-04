using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour {

    public float speed = 20f;
    public float MaxSpeed = 5f;
    public float easeVelocity;
    public LayerMask Whatisgnd;
    [Range(0, 1)] public float smoothness = 0.5f;
    private Rigidbody rb;
    private Vector3 move;
    private Vector3 rotate;
    public float jumpPow = 3f;
    public bool Grounded = false;
    public Transform gngcheck;
    public float rad;
    public Transform cam;
    private Vector3 CamForward;
    private float v;
    private float h;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        gngcheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // calls the move function
        Move();
    }

    void FixedUpdate()
    {
      
    }

    void Move()
    {
        move = new Vector3(h, 0, v) * speed;

        // setting floats for parameters in animator controller
        anim.SetFloat("SpeedX",Mathf.Abs(h));
        anim.SetFloat("SpeedY",Mathf.Abs(v));

        // fake friction is equel to the rigidbody's velocity
        Vector3 easeVelo = rb.velocity;
        easeVelo.y = rb.velocity.y;
        easeVelo.z *= rad;
        easeVelo.x *= rad;
        // inputs up/down keys or W and S
        v = Input.GetAxis("Vertical");
        // inputs Left/right keys or A and D
        h = Input.GetAxis("Horizontal");

        // if h or v is not 0 then player looks in diffrent direction 
        if (h != 0 || v != 0)
        {
            rotate = new Vector3(h, 0, v);
            Quaternion rotation = Quaternion.LookRotation(rotate);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothness);
        }
        Debug.DrawRay(gngcheck.position, -transform.up);
        if (Physics.Raycast(gngcheck.position, -transform.up))
        {
            Grounded = false;
            // rbs velocity is equel to fake friction (In Mid Air) 
            rb.velocity = easeVelo;
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, easeVelocity);
            Grounded = true;
        }
        // make sure you dont go over your max speed
        if(rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(move);
        }
        // fake friction
        if (Grounded)
        {
            rb.velocity = easeVelo;
        }
    }
}
 