using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : Enemy
{
    [Header("WalkingTimeBomb")]
    public GameObject OnselfDesturct;
    //adds a explosion sphere
    public SphereCollider explosionShere;
    public float explosionDelay = 2f;
    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // this is called when the player is near
    protected override void Attack()
    {
        StartCoroutine(StartDestruction(explosionDelay));
    }

    IEnumerator StartDestruction(float delay)
    {
        // this sets the trigger to the parameters from the animator controller
        anim.SetTrigger("Explode");


        yield return new WaitForSeconds(delay);
        
        // if the bomber is close to player he'll start to ignite

        if(IsAtTarget())
        {
            SelfDestruct();
        }
        else

        // when the player moves away quick enough, he'll cancel the explosion

        {
            anim.SetTrigger("Deactivate");
        }
    }



    void SelfDestruct()
    {
        hp = 0;
        PlayExplosion();
    }
    // plays the explosion
    void PlayExplosion()
    {
        // instaniates the exploson prefab
        GameObject explosion = Instantiate(OnselfDesturct);
        explosion.transform.position = transform.position;
    }

}
