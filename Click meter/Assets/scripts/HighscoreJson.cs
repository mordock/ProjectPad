using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.SimpleAndroidNotifications;

public class HighscoreJson : MonoBehaviour {
	private string path;

	public HighscoreJson(){
		path = Application.persistentDataPath + "/Highscore.json";
	}
	public void createHighscore(){
		if(!File.Exists(path)){
			File.Create(path).Close();
			File.WriteAllText(path, "[" + ScoreKeeper.score + "]");
		}
	}
}
