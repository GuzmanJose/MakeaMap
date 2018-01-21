using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WriteManageSC : MonoBehaviour {

	public InputField input;
	public Text textBox;
	public Canvas myCanvas;

	private Text textClone;
	private GameObject wButtonElem;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateText () {
		textClone = Instantiate (textBox, this.transform.position, Quaternion.identity);
		textClone.transform.SetParent (myCanvas.transform, false);
		textClone.text = input.text;
		input.text = "";
		this.gameObject.SetActive (false);
		wButtonElem = GameObject.FindGameObjectWithTag ("Write");
		wButtonElem.GetComponent <ButtonElementScript> ().textOn = false;
	} 


}
