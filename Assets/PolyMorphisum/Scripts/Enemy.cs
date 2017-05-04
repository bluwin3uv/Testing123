using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Charater
{
    [Header("Enemy")]

    // the Enemy will follow this
    public Transform target;
    protected NavMeshAgent agent;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        SeekToTarget();

        // if the player is dead
        if(CheckDeath())
        {
            // completley removes the object from the scene
            Destroy(gameObject);
        }
    }

    protected virtual void FixedUpdate()
    {
        // if arppoches the player then will start attacking
        if(IsAtTarget())
        {
            Attack();
        }
    }

    // this is used for inheretants
    protected virtual void Attack() { }

    protected void SeekToTarget()
    {
        // if the target is not empty and with navmesh on then its follows the target's position
        if(target != null && agent.enabled)
        {
            agent.SetDestination(target.position);
        }
    }

    protected bool IsAtTarget()
    {
        if(!agent.hasPath)
        {
            return false;
        }
        return agent.remainingDistance <= agent.stoppingDistance;
    }
}
