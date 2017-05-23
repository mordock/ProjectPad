using Assets.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.SimpleAndroidNotifications;

namespace Assets.classes
{
    /// <summary>
    /// AUTHOR: Giel Jurriëns STUDENTNUMMER:500749216
    /// </summary>
    class Cyclus
    {
        [JsonProperty]
        private List<TimeSpan> monday { get; set; }
        [JsonProperty]
        private List<TimeSpan> tuesday { get; set; }
        [JsonProperty]
        private List<TimeSpan> wednesday { get; set; }
        [JsonProperty]
        private List<TimeSpan> thursday { get; set; }
        [JsonProperty]
        private List<TimeSpan> friday { get; set; }
        [JsonProperty]
        private List<TimeSpan> saturday { get; set; }
        [JsonProperty]
        private List<TimeSpan> sunday { get; set; }

        private string path = Application.persistentDataPath + "/Cyclus.json";

        public Cyclus() {
            monday = new List<TimeSpan>();
            tuesday = new List<TimeSpan>();
            wednesday = new List<TimeSpan>();
            thursday = new List<TimeSpan>();
            friday = new List<TimeSpan>();
            saturday = new List<TimeSpan>();
            sunday = new List<TimeSpan>();
        }
        /// <summary>
        /// Read all dateTimes from the AppOpenDate.json file and sort them to days and store the just the times per day in json cyclus.json.
        /// </summary>
        /// <param name="appOpenDateList">The list of data taken from AppOpenDate.json</param>
        public void createCyclus(List<AppOpenDate> appOpenDateList) {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                foreach (AppOpenDate item in appOpenDateList) {
                    //Get day of week from datetime to check in what list the timespan belongs
                    DayOfWeek dayOfWeek = item.datetimeOpened.DayOfWeek;
                    TimeSpan time = item.datetimeOpened.TimeOfDay;
                    //Add time to the correct list
                    switch (dayOfWeek) {
                        case DayOfWeek.Monday:
                            monday.Add(time);
                            break;
                        case DayOfWeek.Tuesday:
                            tuesday.Add(time);
                            break;
                        case DayOfWeek.Wednesday:
                            wednesday.Add(time);
                            break;
                        case DayOfWeek.Thursday:
                            thursday.Add(time);
                            break;
                        case DayOfWeek.Friday:
                            friday.Add(time);
                            break;
                        case DayOfWeek.Saturday:
                            saturday.Add(time);
                            break;
                        case DayOfWeek.Sunday:
                            sunday.Add(time);
                            break;
                    }
                }
                //sort all list from first to last
                for (var i = 0; i < 7; i++)
                {
                    switch (i)
                    {
                        case 0:
                            monday.Sort();
                            break;
                        case 1:
                            tuesday.Sort();
                            break;
                        case 2:
                            wednesday.Sort();
                            break;
                        case 3:
                            thursday.Sort();
                            break;
                        case 4:
                            friday.Sort();
                            break;
                        case 5:
                            saturday.Sort();
                            break;
                        case 6:
                            sunday.Sort();
                            break;
                    }
                }

                File.WriteAllText(path, JsonConvert.SerializeObject(this, Constants.jsonSerializerSettings));
                Cyclus cyclus = readCyclus();
                sendNotification(0, cyclus);
            }
            else {
                //cyclus is already created create send notifications
                Cyclus cyclus = readCyclus();
                sendNotification(0, cyclus);
            }  
        }

        /// <summary>
        /// Set the notification in android for entire week
        /// </summary>
        public void sendNotification(int daysAdded, Cyclus cyclus) {
            int minMinutes = 15;
            DayOfWeek today;
            if (daysAdded > 0)
            {
                today = DateTime.Now.AddDays(daysAdded).DayOfWeek;
            }
            else
            {
                today = DateTime.Now.DayOfWeek;
            }
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            List<TimeSpan> todayTimes;

            switch (today) {
                case DayOfWeek.Monday:
                    todayTimes = cyclus.monday;
                    break;
                case DayOfWeek.Tuesday:
                    todayTimes = cyclus.tuesday;
                    break;
                case DayOfWeek.Wednesday:
                    todayTimes = cyclus.wednesday;
                    break;
                case DayOfWeek.Thursday:
                    todayTimes = cyclus.thursday;
                    break;
                case DayOfWeek.Friday:
                    todayTimes = cyclus.friday;
                    break;
                case DayOfWeek.Saturday:
                    todayTimes = cyclus.saturday;
                    break;
                default:
                    todayTimes = cyclus.sunday;
                    break;
            }

            NotifScript notif = new NotifScript();
            if (daysAdded == 0)
            {
                notif.cancelAll();
            }
            foreach (TimeSpan item in todayTimes)
            {
                TimeSpan differenceTime = item - currentTime;
                if (differenceTime.TotalMinutes > minMinutes)
                {
                    notif.SendNotification(differenceTime);
                }
            }

            if (daysAdded < 6)
            {
                sendNotification(daysAdded+1, cyclus);
            }

        }

        /// <summary>
        /// Read cyclus.json file
        /// </summary>
        /// <returns>Cyclus object filled with data from json file</returns>
        public Cyclus readCyclus() {
            Cyclus cyclus;
            using (StreamReader r = new StreamReader(path)) {
                string json = r.ReadToEnd();
                cyclus = JsonConvert.DeserializeObject<Cyclus>(json, Constants.jsonSerializerSettings);
                r.Close();
            }
            return cyclus;
        }
    }
}
