using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UiSliderScr : MonoBehaviour {


	private GameObject[] elements;
	private Sprite[] buttonImages;

	public GameObject buttonElement;


	// Use this for initialization
	void Start () {
		if (elements == null) {
			elements = Resources.LoadAll ("Elements", typeof(GameObject)).Cast<GameObject>().ToArray();
			buttonImages = Resources.LoadAll ("ButtonImages", typeof(Sprite)).Cast<Sprite>().ToArray();
			for (int i = 0; i < elements.Length; i++) {
				GameObject cloneButton = Instantiate (buttonElement, new Vector3(1 + (elements[i].GetComponent <BoxCollider2D>().size.x * 11) * i, 1f, 85f), Quaternion.identity);
				cloneButton.GetComponent<ButtonElementScript>().stamp = elements[i];
				cloneButton.GetComponent <ButtonElementScript>().buttonImage = buttonImages[i];
				if (elements[i].tag == "element") {
					cloneButton.tag = "element";
				}
				else if (elements[i].tag == "Draw") {
					cloneButton.tag = "Draw";
				}
				else if (elements[i].tag == "Erase") {
					cloneButton.tag = "Erase";
				}
				else if (elements[i].tag == "Write") {
					cloneButton.tag = "Write";
				}

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
