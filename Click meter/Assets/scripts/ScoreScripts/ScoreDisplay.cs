using Assets.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.SimpleAndroidNotifications;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = ScoreKeeper.score.ToString();

		ScoreKeeper.Reset();
		//HighscoreJson.createHighscore();
	}
}
