using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name){
		Debug.Log("level loaded: " + name);
        SceneManager.LoadScene(name);
		//Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log("game quit");
		Application.Quit();
	}
}
