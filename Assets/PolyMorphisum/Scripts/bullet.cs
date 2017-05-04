using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int dmg = 1;
    public GameObject explode;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(0, 0, -0.5f);
	}

    void OnCollisionEnter(Collision other)
    {
        transform.Translate(0, 0, 0);
        Destroy(gameObject);
        PlayExplosion();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }


    void PlayExplosion()
    {
        GameObject clone = Instantiate(explode);
        clone.transform.position = transform.position;
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();
        Destroy(clone, 5f);   }
}
