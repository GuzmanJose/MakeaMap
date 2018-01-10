using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCameraDisplay : MonoBehaviour {

	WebCamTexture tex;
	public RawImage display;

	// Use this for initialization
	void Start () {
		StartStopCam ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartStopCam () {

		if (tex != null) {
			display.texture = null;
			tex.Stop ();
			tex = null;
		} else {
			WebCamDevice device = WebCamTexture.devices [0];
			tex = new WebCamTexture (device.name);
			display.texture = tex;
			tex.Play ();	
		}
	}



}
