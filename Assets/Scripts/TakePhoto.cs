using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour {

	GameObject uiSlider;
	GameObject subSlider;
	GameObject photoButton;
	GameObject stampSlider;
	private GameObject wizard;
	private GameObject draw;
	private GameObject scrollers;

	void Awake () {
		scrollers = GameObject.Find ("SCROLLS");
		draw = GameObject.Find ("FreeDrawManager");
		wizard = GameObject.Find ("Wizard");
		subSlider = GameObject.Find ("IslandSlider");
		uiSlider = GameObject.Find ("UiSliderMain");
		stampSlider = GameObject.Find ("StampSlider");
		photoButton = GameObject.Find ("Next");
	}

	// Use this for initialization
	void Start () {
		wizard.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void CleanUI () {
		GameControl.control.roundNumber++;
		uiSlider.SetActive (false);
		subSlider.SetActive (false);
		stampSlider.SetActive (false);
		photoButton.SetActive (false);
		scrollers.SetActive (false);
		draw.SetActive (false);
		ScreenCapture.CaptureScreenshot ("Assets/ScreenPics/" + GameControl.control.roundNumber + "MapPic.png");
		StartCoroutine (Wizard ());
	}

	public void PicReady () {
		SceneManager.LoadScene ("InputMail");
	}

	public void NotYet() {
		subSlider.SetActive (true);
		stampSlider.SetActive (true);
		uiSlider.SetActive (true);
		photoButton.SetActive (true);
		scrollers.SetActive (true);
		wizard.SetActive (false);
	}

	IEnumerator Wizard () {
		yield return new WaitForSeconds (2);
		wizard.SetActive (true);
	}





}
