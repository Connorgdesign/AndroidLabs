using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TidePredictionsSql
{
    class TidePrediction
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Height { get; set; }
        public string Hi_Low { get; set; }
    }
}