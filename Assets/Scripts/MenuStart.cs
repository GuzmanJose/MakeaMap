using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameControl.control.Load ();
	}


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadMapBuilder () {
		SceneManager.LoadScene ("MapBuilder");
	}

}
