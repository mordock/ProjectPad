using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioScource;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	void Start(){
		audioScource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic){
			audioScource.clip = thisLevelMusic;
			audioScource.loop = true;
			audioScource.Play();
		}
	}
}
