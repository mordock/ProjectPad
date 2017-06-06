using UnityEngine;
using UnityEngine.UI;

public class highscoreDisplay : MonoBehaviour
{
    //shows your score
    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();
    }
}