using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public static int score;
	private Text myText;
	//create text and fill it with the score
	void Start () {
		myText = GetComponent<Text>();
	}
	//score is increased by points, amount is given in Mousecollision(scoreValue)
	public void Score(int points){
		score += points;
		myText.text = score.ToString();
	}

	public static void Reset(){
		score = 0;
	}
}