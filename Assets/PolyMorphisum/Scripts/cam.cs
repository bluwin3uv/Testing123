using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cam : MonoBehaviour
{
    public WebCamTexture camm = null;
    public GameObject Screen;
	
	void Start ()
    { 
        camm = new WebCamTexture();
        
	}
	
	void Update ()
    {
		
	}
}
