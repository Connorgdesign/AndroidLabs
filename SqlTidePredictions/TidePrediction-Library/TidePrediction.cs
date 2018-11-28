using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TidePrediction_Library
{
    public class TidePrediction
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Height { get; set; }
        public string Hi_Low { get; set; }

        public TidePrediction()
        {

        }

        public TidePrediction(string city, string date, string day, string time, string height, string high_low)
        {
            City = city;
            Date = date;
            Day = day;
            Time = time;
            Height = height;
            Hi_Low = high_low;
        }
    }

}
