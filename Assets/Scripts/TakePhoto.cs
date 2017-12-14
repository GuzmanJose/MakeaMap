using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeScreenPic () {
		ScreenCapture.CaptureScreenshot ("Assets/ScreenPics/ScreenPic.png");
	}

}
