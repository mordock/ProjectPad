using Assets.scripts.classes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //create text and fill it with the score, set score to 0 for next game
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();
        HighScoresJSON highScoreJson = new HighScoresJSON();
        List<int> highScores = highScoreJson.WriteToJSON(ScoreKeeper.score);
        highScore1.text = highScores[0].ToString();
        highScore2.text = highScores[1].ToString();
        highScore3.text = highScores[2].ToString();

        ScoreKeeper.Reset();
    }
}