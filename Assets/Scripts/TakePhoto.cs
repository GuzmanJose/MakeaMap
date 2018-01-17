using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour {

	GameObject uiSlider;
	GameObject subSlider;
	GameObject photoButton;
	private GameObject wizard;
	private GameObject draw;
	private GameObject scroller;
	private int screenTaken;



	void Awake () {
		scroller = GameObject.Find ("Scroller");
		draw = GameObject.Find ("FreeDrawManager");
		wizard = GameObject.Find ("Wizard");
		subSlider = GameObject.Find ("IslandSlider");
		uiSlider = GameObject.Find ("UiSliderMain");
		photoButton = GameObject.Find ("Next");
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
		subSlider.SetActive (false);
		photoButton.SetActive (false);
		draw.SetActive (false);
		ScreenCapture.CaptureScreenshot ("Assets/ScreenPics/MapPic.png");
		StartCoroutine (Wizard ());
	}

	public void PicReady () {
		SceneManager.LoadScene ("InputMail");
	}

	public void NotYet() {
		subSlider.SetActive (true);
		uiSlider.SetActive (true);
		photoButton.SetActive (true);
		wizard.SetActive (false);
	}

	IEnumerator Wizard () {
		yield return new WaitForSeconds (2);
		wizard.SetActive (true);
	}





}
