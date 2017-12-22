using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eraseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
		if (transform.parent.tag == "element") {
			transform.parent.GetComponent<ElementScript1>().EraseElement();		
		}
		else if (transform.parent.tag == "Write") {
			transform.parent.GetComponent<TextElementSC>().EraseElement();
		}
      
    }
}
