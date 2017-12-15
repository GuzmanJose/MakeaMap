using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ElementScript1 : MonoBehaviour {


	private Vector3 cursorPos;
    private GameObject erase;
    private float eraseDistance;

	public bool mouseOn = false;
    public GameObject eraseButton;


	// Use this for initialization
	void Start () {
    erase = Instantiate(eraseButton, new Vector3(transform.position.x + eraseDistance, transform.position.y + eraseDistance, transform.position.z), Quaternion.identity );
    erase.transform.parent = this.transform;


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

        eraseDistance = GetComponent<BoxCollider2D>().size.x * 3;

    }
		
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			mouseOn = true;
			SelectOn ();
		} 			
	}

	void SelectOn () {
        GetComponent<Outline>().enabled = true;
        erase.SetActive(true);
    }
    
    void SelectOff() {
        GetComponent<Outline>().enabled = false;
        erase.SetActive(false);
    }

    public void EraseElement() {
        Destroy(gameObject);
    }

}
