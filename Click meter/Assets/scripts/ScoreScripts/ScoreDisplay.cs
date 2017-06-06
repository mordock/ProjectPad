using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //create text and fill it with the score, set score to 0 for next game
    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();

        ScoreKeeper.Reset();
    }
}