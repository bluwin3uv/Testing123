using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caamm : MonoBehaviour {
    public WebCamTexture mCamera = null;
    public GameObject plane;
    private bool cama;
	void Start ()
    {
        Debug.Log("Script has been started");
        plane = GameObject.FindWithTag("Player");
        //mCamera = new WebCamTexture();
        WebCamDevice[] dev = WebCamTexture.devices;
        if(dev.Length == 0)
        {
            cama = false;
            return;
        }
        for(int i =0;i<dev.Length;i++)
        {
            if(!dev[i].isFrontFacing)
            {
                mCamera = new WebCamTexture(dev[i].name,128,128);
            }
        }
        if (mCamera == null)
        {
            return;
        }
        mCamera.Play();
        plane.GetComponent<Renderer>().material.mainTexture = mCamera;
        cama = true;
    }

    void Update ()
    {
       		
	}
}
