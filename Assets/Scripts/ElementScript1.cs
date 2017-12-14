using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ElementScript1 : MonoBehaviour {

	private Vector3 cursorPos;
	public bool mouseOn = false;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (mouseOn ) {
			cursorPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 88f);
			this.transform.position = Camera.main.ScreenToWorldPoint (cursorPos);
		} else {
			this.transform.position = this.transform.position;	
		}
		if (Input.GetMouseButtonUp(0)) {
			mouseOn = false;

		}


	}
		
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			GetComponent <Outline> ().enabled = true;
			mouseOn = true;
			SelectOn ();
		} 
			
	}

	void OnMouseExit () {
		GetComponent <Outline> ().enabled = false;
	}
		
	void SelectOn () {
		//add x sprite

	}


}
