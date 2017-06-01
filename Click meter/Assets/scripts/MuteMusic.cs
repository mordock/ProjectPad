using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour {
	public static bool pause = false;
	//pause the music when you press the mute button, and continue when unmute is pressed
	void MutetheMusic(){
		if(pause == false){
			pause = true;
		}else if(pause == true){
			pause = false;
		}
	}	
}