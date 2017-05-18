using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour {
	public static int baseLives = 5;
	
	// Update is called once per frame
	void Update () {
		if(baseLives <= 0){
			Application.LoadLevel("GameOver");
            baseLives = 5;
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(3,3,20,20), baseLives.ToString());
	}
}