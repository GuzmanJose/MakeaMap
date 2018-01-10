using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakePhoto : MonoBehaviour {

	GameObject uiSlider;
	GameObject photoButton;
	private GameObject wizard;
	private GameObject draw;
	private int screenTaken;



	void Awake () {
		draw = GameObject.Find ("FreeDrawManager");
		wizard = GameObject.Find ("Wizard");
		uiSlider = GameObject.Find ("UiSlider");
		photoButton = GameObject.Find ("PhotoButton");
	}

	// Use this for initialization
	void Start () {
		screenTaken = 1;
		wizard.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void CleanUI () {
		uiSlider.SetActive (false);
		photoButton.SetActive (false);
		draw.SetActive (false);
		ScreenCapture.CaptureScreenshot ("Assets/ScreenPics/MapPic.png");
		StartCoroutine (Wizard ());
	}

	public void PicReady () {
		SceneManager.LoadScene ("InputMail");
	}

	public void NotYet() {
		uiSlider.SetActive (true);
		photoButton.SetActive (true);
		wizard.SetActive (false);
	}

	IEnumerator Wizard () {
		yield return new WaitForSeconds (2);
		wizard.SetActive (true);
	}





}
