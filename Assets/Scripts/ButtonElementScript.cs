using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElementScript : MonoBehaviour {

	public GameObject stamp;
	public Sprite buttonImage;

	private GameObject draw;
	private SpriteRenderer spriteRen;

	void Awake () {
		draw = GameObject.Find ("FreeDrawManager");
	}

	// Use this for initialization
	void Start () {
		spriteRen = GetComponent <SpriteRenderer> ();
		spriteRen.sprite = buttonImage;
		draw.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "element") {
			GameObject cloneElement = Instantiate (stamp, this.transform.position, Quaternion.identity);
			cloneElement.GetComponent <ElementScript1>().mouseOn = true;
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Draw" && !draw.activeSelf) {
			draw.SetActive (true);
		} else if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Draw" && draw.activeSelf) {
			draw.SetActive (false);
		}
		if (Input.GetMouseButtonDown (0) && this.gameObject.tag == "Erase") {
			GameObject[] lines;
			lines = GameObject.FindGameObjectsWithTag ("Line");
			foreach (var line in lines) {
				Destroy (line);
			}
		}
	}
		

}
