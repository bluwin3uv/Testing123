using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRotation : MonoBehaviour {

    public float playerRotation;
    private GameObject player;
    public Quaternion rot;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mm0");
    }
	
	void Update ()
    {
       // playerRotation = player.transform.rotation.y;
        gameObject.transform.localRotation = player.transform.localRotation;
	}
}
