using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normmm : MonoBehaviour {
    public float vaw;
    public float x, y, z;
    private GameObject player;
    private Vector3 scale;
    private Vector3 halfScale;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("mm0");
	}

	void Update ()
    {
        //gameObject.transform.localPosition = player.transform.localPosition / vaw;
        gameObject.transform.Translate(x, 0, y);
	}
}
