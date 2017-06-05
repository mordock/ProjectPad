using Assets.Classes;
using Assets.SimpleAndroidNotifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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


        public Cyclus()
        {
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
        public void createCyclus(List<AppOpenDate> appOpenDateList)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                foreach (AppOpenDate item in appOpenDateList)
                {
                    //Get day of week from datetime to check in what list the timespan belongs
                    DayOfWeek dayOfWeek = item.datetimeOpened.DayOfWeek;
                    TimeSpan time = item.datetimeOpened.TimeOfDay;
                    //Add time to the correct list
                    switch (dayOfWeek)
                    {
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
            else
            {
                //cyclus is already created create send notifications 
                Cyclus cyclus = readCyclus();
                sendNotification(0, cyclus);
            }
        }

        /// <summary>
        /// Set the notification in android for entire week
        /// </summary>
        public void sendNotification(int daysAdded, Cyclus cyclus)
        {
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

            switch (today)
            {
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
                sendNotification(daysAdded + 1, cyclus);
            }

        }

        /// <summary>
        /// Read cyclus.json file
        /// </summary>
        /// <returns>Cyclus object filled with data from json file</returns>
        public Cyclus readCyclus()
        {
            Cyclus cyclus;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                cyclus = JsonConvert.DeserializeObject<Cyclus>(json, Constants.jsonSerializerSettings);
                r.Close();
            }
            return cyclus;
        }

        //Remco Schilder
        public void ChangeCyclus()
        {
            Cyclus cyclus = readCyclus();
            int CountNotifications;

            for (int i = 0; i < 7; i++)
            {

                int sigarettesPerDay;

                //count the amount of notifications for every day of hte week
                switch (i)
                {
                    case 0:
                        sigarettesPerDay = cyclus.monday.Count;
                        break;
                    case 1:
                        sigarettesPerDay = cyclus.tuesday.Count;
                        break;
                    case 2:
                        sigarettesPerDay = cyclus.wednesday.Count;
                        break;
                    case 3:
                        sigarettesPerDay = cyclus.thursday.Count;
                        break;
                    case 4:
                        sigarettesPerDay = cyclus.friday.Count;
                        break;
                    case 5:
                        sigarettesPerDay = cyclus.saturday.Count;
                        break;
                    default:
                        sigarettesPerDay = cyclus.sunday.Count;
                        break;
                }

                /*calculation to delete a small amount of notifications for each amount of notifications 
                 * if the person clicked "Yes" at the question scene
                 */
                if (sigarettesPerDay <= 10)
                {
                    CountNotifications = Convert.ToInt32(Math.Round(sigarettesPerDay * 0.10));
                }
                else if (sigarettesPerDay <= 20)
                {
                    CountNotifications = Convert.ToInt32(Math.Round(sigarettesPerDay * 0.20));
                }
                else
                {
                    CountNotifications = Convert.ToInt32(Math.Round(sigarettesPerDay * 0.30));
                }

                //remove the notifications for every day of the week
                for (int j = 0; j < CountNotifications; j++)
                {
                    switch (i)
                    {
                        case 0:
                            cyclus.monday.RemoveAt(0);
                            break;
                        case 1:
                            cyclus.tuesday.RemoveAt(0);
                            break;
                        case 2:
                            cyclus.wednesday.RemoveAt(0);
                            break;
                        case 3:
                            cyclus.thursday.RemoveAt(0);
                            break;
                        case 4:
                            cyclus.friday.RemoveAt(0);
                            break;
                        case 5:
                            cyclus.saturday.RemoveAt(0);
                            break;
                        default:
                            cyclus.sunday.RemoveAt(0);
                            break;
                    }
                }
            }

            //write to cyclus.json
            File.WriteAllText(path, JsonConvert.SerializeObject(cyclus, Constants.jsonSerializerSettings));
        }
    }
}
