using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public int roundNumber;
	public static GameControl control;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != null) {
			Destroy (gameObject);	
		}
				

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "roundNum.dat");

		RoundNumber data = new RoundNumber ();
		data.roundNumber = roundNumber;

		bf.Serialize (file, data);
		file.Close ();
	
	}

	public void Load () {
		if (File.Exists (Application.persistentDataPath + "roundNum.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "roundNum.dat", FileMode.Open);
			RoundNumber data = (RoundNumber)bf.Deserialize (file);
			file.Close ();

			roundNumber = data.roundNumber;
		}
	}





	[Serializable]
	class RoundNumber {
		public int roundNumber;

	}


}
