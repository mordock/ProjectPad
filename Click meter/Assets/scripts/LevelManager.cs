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

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            string lastScene;
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "help")
            {
                lastScene = "Clickmeter";
            } else if (currentScene == "Video" || currentScene == "FruitDefence")
            {
                lastScene = "MainMenu";
            } else if (currentScene == "Highscore" || currentScene == "level_1" || currentScene == "GameOver" || currentScene == "tutorial")
            {
                lastScene = "FruitDefence";
            } else {
                lastScene = currentScene;
            }
            LoadLevel(lastScene);
        }
    }
}
