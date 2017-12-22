﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TextElementSC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Vector3 cursorPos;
	private GameObject erase;
	private bool pointerOn;


	public bool mouseOn = false;
	public GameObject eraseButton;



	// Use this for initialization
	void Start () {
		EraseButton ();	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && pointerOn) {  
			if (EventSystem.current.IsPointerOverGameObject() && gameObject.tag == "Write") { 
				mouseOn = true;
				SelectOn();
			}
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && !pointerOn) {  
			if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId) && gameObject.tag == "Write") { 
				mouseOn = true;	
				SelectOn(); 
			}
		} 
		if (mouseOn) {
			cursorPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 88f);
			this.transform.position = Camera.main.ScreenToWorldPoint (cursorPos);
		}

		else {
			this.transform.position = this.transform.position;					
		}
		if (Input.GetMouseButtonUp(0)) {
			mouseOn = false;

		}
		if (Input.GetMouseButtonDown(0) && !mouseOn) {
			SelectOff();
		}

		if (Input.touchCount == 2) {
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitude = prevTouchDeltaMag - touchDeltaMag;

			this.transform.localScale += new Vector3(deltaMagnitude, deltaMagnitude, 0f);
		}



	}

	public void OnPointerEnter(PointerEventData eventData) {
		pointerOn = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		pointerOn = false;
	}




	void SelectOn () {
		erase.SetActive(true);
	}

	void SelectOff() {
		erase.SetActive(false);
	}

	void EraseButton(){
		erase = Instantiate(eraseButton, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity );
		erase.transform.parent = this.transform;	
	}

	public void EraseElement() {
		Destroy(gameObject);
	}
}
