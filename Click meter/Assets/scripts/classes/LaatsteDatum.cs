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

        //get the last date of the first week of the cyclus
        public DateTime GetLastDate()
        {
            DateTime laatstedatum;
            if (!File.Exists(path))
            {
                laatstedatum = DateTime.Now;
            }
            else
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    laatstedatum = JsonConvert.DeserializeObject<DateTime>(json, Constants.jsonSerializerSettings);
                    r.Close();
                }
            }
            return laatstedatum.ToLocalTime();
        }

        //write the last date to CyclusManager.json
        public void WriteFirstDate(DateTime date)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            lastDate = date.AddDays(week);
            File.WriteAllText(path, JsonConvert.SerializeObject(lastDate, Constants.jsonSerializerSettings));
        }

        //Show scene after 7 days (week)
        public void CreateFirstDate(DateTime date)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                lastDate = date.AddDays(week);
                File.WriteAllText(path, JsonConvert.SerializeObject(lastDate, Constants.jsonSerializerSettings));
            }
        }
    }
}