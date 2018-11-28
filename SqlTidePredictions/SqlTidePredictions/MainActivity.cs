using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System.IO;
using TidePrediction_Library;
using System.Linq;
using System;
using Android.Content;

namespace SqlTidePredictions
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        const string CITY = "City";
        const string DATE = "Date";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

            string dbPath = "";
            SQLiteConnection db = null;

            // Get the path to the database that was deployed in Assets
            dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "tides.db3");

            // It seems you can read a file in Assets, but not write to it
            // so we'll copy our file to a read/write location
            using (Stream inStream = Assets.Open("tides.db3"))
            using (Stream outStream = File.Create(dbPath))
                inStream.CopyTo(outStream);

            // Open the database
            db = new SQLiteConnection(dbPath);

            // Initialize the adapter for the spinner with stock symbols
            var locations = db.Table<TidePrediction>().GroupBy(c => c.City).Select(c => c.First());
            var cities = locations.Select(c => c.City).ToList();
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, cities);

            var tideSpinner = FindViewById<Spinner>(Resource.Id.mainSpinner);
            tideSpinner.Adapter = adapter;

            // Event handler for selected spinner item
            string selectedCity = "";
            tideSpinner.ItemSelected += delegate (object sender, AdapterView.ItemSelectedEventArgs e) {
                Spinner spinner = (Spinner)sender;
                selectedCity = (string)spinner.GetItemAtPosition(e.Position);
            };

            /* ------- DatePicker initialization ------- */

            var datePicker = FindViewById<DatePicker>(Resource.Id.datePicker);

            TidePrediction firstDateCity =
                db.Get<TidePrediction>((from c in db.Table<TidePrediction>() select c).Min(c => c.ID));
            string firstDate = firstDateCity.Date;
            datePicker.DateTime = Convert.ToDateTime(firstDate);

            Button showTidesButton = FindViewById<Button>(Resource.Id.showTidesButton);
            showTidesButton.Click += delegate {
                var back = new Intent(this, typeof(SecondActivity));

                //get the date in a string format that matches the database
                string chosenDate = datePicker.DateTime.ToString("yyyy/MM/dd");

                back.PutExtra(CITY, selectedCity);
                back.PutExtra(DATE, chosenDate);
                
                StartActivity(back);
            };



        }
    }
}