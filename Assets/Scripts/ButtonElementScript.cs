using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElementScript : MonoBehaviour {

	public GameObject stamp;
	public Sprite buttonImage;

	private SpriteRenderer spriteRen;
	private Vector3 cursorPos;


	// Use this for initialization
	void Start () {
		spriteRen = GetComponent <SpriteRenderer> ();
		spriteRen.sprite = buttonImage;
	}
	
	// Update is called once per frame
	void Update () {
		cursorPos = Input.mousePosition;
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject cloneElement = Instantiate (stamp, this.transform.position, Quaternion.identity);
			cloneElement.GetComponent <ElementScript1>().mouseOn = true;
		}
	}
		

}
