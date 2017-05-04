using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class birdman : Enemy
{
    [Header("BirdMan")]
    private Animator anim;
    public float attackDel = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected override void Attack()
    {
        
    }

    IEnumerator StartAttack(float delay)
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(delay);
        if(IsAtTarget())
        {
            Attacking();
        }
        else
        {
            anim.SetTrigger("Stop");
        }
    }

    void Attacking()
    {

    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Bullet")
        {
            Damage(3);
            Destroy(gameObject, 2);
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
    
    public void Damage(int dmg)
    {
        hp -= dmg;
        anim.SetTrigger("ded");
        print("ded");
    }

}
