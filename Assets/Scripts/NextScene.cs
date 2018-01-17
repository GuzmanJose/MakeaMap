using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (NextScene1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator	NextScene1 () {
		yield return new WaitForSeconds (5.0f);
		SceneManager.LoadScene ("StartScene");
	}

}
