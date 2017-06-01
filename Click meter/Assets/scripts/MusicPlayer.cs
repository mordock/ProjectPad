using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	//when run for the first time, start the music after that, destroy the new player so the music doesn't restart when entering the scene again
	void Awake(){
		if(instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			//doesn't destoy the music player, so it will continue playing even when switching scenes
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
