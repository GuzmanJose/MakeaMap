using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonElementScript : MonoBehaviour {

	public GameObject stamp;
	public Sprite buttonImage;

	private GameObject write;
	private GameObject draw;
	private SpriteRenderer spriteRen;
	private GameObject mainSlider;
	private GameObject subSlider;
	private GameObject scroller;

	void Awake () {
		scroller = GameObject.Find ("Scroller");
		draw = GameObject.Find ("FreeDrawManager");
		write = GameObject.Find ("WriteManager");
		subSlider = GameObject.Find ("IslandSlider");
		mainSlider = GameObject.Find ("UiSliderMain");
	}

	// Use this for initialization
	void Start () {
		spriteRen = GetComponent <SpriteRenderer> ();
		spriteRen.sprite = buttonImage;
		write.SetActive (false);
		draw.SetActive (false);
		//subSlider.SetActive (false);
		subSlider.transform.position = new Vector3 (subSlider.transform.position.x, -2f, subSlider.transform.position.z);
		scroller.GetComponent <ScrollRect>().horizontal = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "element") {
			GameObject cloneElement = Instantiate (stamp, this.transform.position, Quaternion.identity);
			cloneElement.GetComponent <ElementScript1>().mouseOn = true;
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Islands") {
			mainSlider.transform.position = new Vector3 (mainSlider.transform.position.x, -2f, mainSlider.transform.position.z);
			subSlider.transform.position = new Vector3 (subSlider.transform.position.x, 0f, subSlider.transform.position.z);
			scroller.GetComponent <ScrollRect>().horizontal = true;

		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "GoBack") {
			mainSlider.transform.position = new Vector3 (mainSlider.transform.position.x, 0f, mainSlider.transform.position.z);
			subSlider.transform.position = new Vector3 (subSlider.transform.position.x, -2f, subSlider.transform.position.z);
			scroller.GetComponent <ScrollRect>().horizontal = false;
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Draw" && !draw.activeSelf) {
			draw.SetActive (true);
			// Change the Icon in the button
		} else if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Draw" && draw.activeSelf) {
			draw.SetActive (false);
			// Change back to the previous icon
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Erase") {
			GameObject[] lines;
			lines = GameObject.FindGameObjectsWithTag ("Line");
			foreach (var line in lines) {
				Destroy (line);
			}
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Write" && !write.activeSelf) {
			write.SetActive (true);
		}
		else if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Write" && write.activeSelf) {
			write.SetActive (false);
		}
	}
		

}
