using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

    public Transform player;
    public float speed;
    private Animator anim;
    public float fieldOfView = 30;
    // Use this for initialization
    public float AttackDistance = 5;
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = player.position - this.transform.position;
        float angle = Vector3.Angle(dir, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position)< 10)
        {
            dir.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);
            anim.SetBool("isIdle", false);
            if(dir.magnitude > AttackDistance )
            {
                this.transform.Translate(0, 0,speed);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
	}
}
