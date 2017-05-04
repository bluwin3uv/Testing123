using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public float rotX, rotY, rotZ;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Rotate(rotX, rotY, rotZ);
	}
}
