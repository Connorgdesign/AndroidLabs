using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using TideTableUsingXmlFile;

namespace TidePredictions
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var reader = new XmlTideFileParser(Assets.Open(@"9434032_annual.xml.txt"));
            var List = reader.TideList;

            List.Sort((x, y) => String.Compare((string)x[XmlTideFileParser.DAY] + (string)x[XmlTideFileParser.DAY],
                      (string)y[XmlTideFileParser.DAY] + (string)y[XmlTideFileParser.DAY],
                    StringComparison.Ordinal));

            ListAdapter = new PredictionAdapter(this, List,
            Resource.Layout.list_item,
            new string[] { XmlTideFileParser.DATE, XmlTideFileParser.DAY, XmlTideFileParser.HI_LOW, XmlTideFileParser.TIME },
            new int[] { Resource.Id.dateTextView, Resource.Id.dayTextView,
            Resource.Id.highlowTextView, Resource.Id.timeTextView});

            ListView.FastScrollEnabled = true;

        }


        protected override void OnListItemClick(ListView l,
            View v, int position, long id)
        {
       
            string prediction = (string)((JavaDictionary<string, object>)ListView.GetItemAtPosition(position))[XmlTideFileParser.HEIGHT];
            Android.Widget.Toast.MakeText(this,
                prediction,
                Android.Widget.ToastLength.Short).Show();
        }
    }

  
}