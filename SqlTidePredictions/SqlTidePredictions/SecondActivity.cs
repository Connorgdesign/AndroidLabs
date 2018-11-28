using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TidePrediction_Library;

namespace SqlTidePredictions
{
    [Activity(Label = "SecondActivity", ParentActivity = typeof(MainActivity))]
    public class SecondActivity : ListActivity
    {

        //TidePrediction[] tidesArray;

        //List<IDictionary<int, object>> tideList = new List<IDictionary<int, object>>();

        const string CITY = "City";
        const string DATE = "Date";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Create your application here
            //get selected city and date from main activity
            string city = Intent.Extras.GetString(CITY);
            string date = Intent.Extras.GetString(DATE);

            string dbPath = "";
            SQLiteConnection db = null;

            dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "tides.db3");

            // copy file to a read/write location
            using (Stream inStream = Assets.Open("tides.db3"))
            using (Stream outStream = File.Create(dbPath))
                inStream.CopyTo(outStream);

            // Open the database
            db = new SQLiteConnection(dbPath);

            var tides = (from t in db.Table<TidePrediction>()
                         where (t.City == city)
                         && (t.Date == date)
                         select t).ToList();

            int count = tides.Count;
            string[] stockInfoArray = new string[count];
            for (int i = 0; i < count; i++)
            {
                stockInfoArray[i] =
                    tides[i].Date.ToString() + "\t\t" + tides[i].Day + "\t\t" + tides[i].Date;
            }

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, stockInfoArray);

            ListView.FastScrollEnabled = true;
      






        }
    }
}
