using System.IO;
using UnityEngine;

public class HighscoreJson : MonoBehaviour
{
    private string path;

    public HighscoreJson()
    {
        path = Application.persistentDataPath + "/Highscore.json";
    }
    public void createHighscore()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            File.WriteAllText(path, "[" + ScoreKeeper.score + "]");
        }
    }
}
