using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubSlider : MonoBehaviour {


	private GameObject[] elements;
	private Sprite[] buttonImages;

	public GameObject buttonElement;


	// Use this for initialization
	void Start () {
		if (elements == null) {
			elements = Resources.LoadAll ("Islands/Islands", typeof(GameObject)).Cast<GameObject>().OrderBy(element => Int32.Parse (element.name)).ToArray();
			buttonImages = Resources.LoadAll ("Islands/IslandsButtonImages", typeof(Sprite)).Cast<Sprite>().ToArray();

			for (int i = 0; i < elements.Length; i++) {
				GameObject cloneButton = Instantiate (buttonElement, new Vector3(1 + (buttonElement.GetComponent <BoxCollider2D>().size.x * 10) * i,  1f, 85f), Quaternion.identity);
				cloneButton.GetComponent<ButtonElementScript>().stamp = elements[i];
				cloneButton.GetComponent <ButtonElementScript>().buttonImage = buttonImages[i];
				cloneButton.transform.SetParent (this.transform);
				if (elements[i].tag == "GoBack") {
					cloneButton.tag = "GoBack";
				}
				else if (elements[i].tag == "element") {
					cloneButton.tag = "element";
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
