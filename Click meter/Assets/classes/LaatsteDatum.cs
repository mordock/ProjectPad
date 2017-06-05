using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace Assets.classes
{
    class LaatsteDatum
    {
        private DateTime lastDate = new DateTime();
        private int week = 7;

        private string path = Application.persistentDataPath + "/CyclusManager.json";

        public DateTime GetLastDate()
        {
            LaatsteDatum laatstedatum;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                laatstedatum = JsonConvert.DeserializeObject<LaatsteDatum>(json, Constants.jsonSerializerSettings);
                r.Close();
            }
            return laatstedatum.lastDate;
        }

        public void WriteFirstDate(DateTime date)
        {
            if (!File.Exists(path))
            {
                lastDate = date;
                lastDate.AddDays(week);

                File.Create(path).Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(lastDate, Constants.jsonSerializerSettings));
            }
        }
    }
}