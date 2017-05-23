using Assets.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Classes
{
    /// <summary>
    /// AUTHOR: Giel Jurriëns STUDENTNUMMER: 500749216
    /// </summary>
    class AppOpenDate
    {
        private const int CALCULATION_DURATION_DAYS = 7;
        private const int MINUTES_BETWEEN_SMOKES = 15;
        [JsonProperty]
        public DateTime datetimeOpened {  get; private set; }
     
        public AppOpenDate() {
            datetimeOpened = DateTime.Now.AddMinutes(1);
        }

        /// <summary>
        /// Write AppOpenDate to a local json file
        /// </summary>
        public void writeToJSON() {
            string path = Application.persistentDataPath + "/AppOpenDate.json";

            //Check if json file is empty or not.

            if (File.Exists(path))
            {
                List<AppOpenDate> appOpenDateList; 
                using (StreamReader r = new StreamReader(path)) {
                    string json = r.ReadToEnd();
                    appOpenDateList = JsonConvert.DeserializeObject<List<AppOpenDate>>(json, Constants.jsonSerializerSettings);
                    foreach (AppOpenDate item in appOpenDateList) {
                        //set to localtime since datetime from json are UTC
                        item.datetimeOpened = item.datetimeOpened.ToLocalTime();
                    }
                    r.Close();
                }               
                
                DateTime endOfCyclusCalculationPeriod = appOpenDateList.First().datetimeOpened.AddDays(CALCULATION_DURATION_DAYS);
                DateTime lastOpened = appOpenDateList.Last().datetimeOpened.AddMinutes(MINUTES_BETWEEN_SMOKES);

                //DateTime is before end of cyclus calculation period and atleast 1 hour after the last datetime added.
                if (datetimeOpened < endOfCyclusCalculationPeriod && lastOpened < datetimeOpened)
                {
                    appOpenDateList.Add(this);
                    File.WriteAllText(path, JsonConvert.SerializeObject(appOpenDateList, Constants.jsonSerializerSettings));
                }
                else if (datetimeOpened >= endOfCyclusCalculationPeriod)
                {
                    Cyclus cyclus = new Cyclus();
                    cyclus.createCyclus(appOpenDateList);
                }
            }
            else {
                //Json file doesn't exist so create file and write down the first datetime
                File.Create(path).Close();
                File.WriteAllText(path, "[" +JsonConvert.SerializeObject(this, Constants.jsonSerializerSettings) +"]");
            } 
        }
    }
}
