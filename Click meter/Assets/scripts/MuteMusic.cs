using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour {
	public static bool pause = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MutetheMusic(){
		if(pause == false){
			pause = true;
		}else if(pause == true){
			pause = false;
		}
	}	
}
