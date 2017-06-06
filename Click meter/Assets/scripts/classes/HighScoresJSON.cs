using Assets.classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.scripts.classes
{
    class HighScoresJSON
    {

        private string path = Application.persistentDataPath + "/HighScores.json";

        [JsonProperty]
        public List<int> highScores;

        public HighScoresJSON()
        {
            highScores = new List<int>();
        }

        /// <summary>
        /// Writes highscores to json file
        /// </summary>
        /// <param name="score">New score </param>
        /// <returns>list of ints</returns>
        public List<int> WriteToJSON(int score)
        {
            HighScoresJSON highScoreJson = new HighScoresJSON();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            else
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    highScoreJson = JsonConvert.DeserializeObject<HighScoresJSON>(json, Constants.jsonSerializerSettings);
                    r.Close();
                }
            }

            highScoreJson.highScores.Add(score);
            //sort from high to low
            highScoreJson.highScores = highScoreJson.highScores.OrderByDescending(i => i).ToList();
            //check if highscore are more then 3 and remove others
            for (int i = 0; i < highScoreJson.highScores.Count; i++)
            {
                if (i > 2)
                {
                    highScoreJson.highScores.RemoveAt(i);
                }

            }
            //write to json file
            File.WriteAllText(path, JsonConvert.SerializeObject(highScoreJson, Constants.jsonSerializerSettings));
            //and return and list<int>
            return highScoreJson.highScores;
        }
    }
}
