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

namespace PigFragment
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.SecondActivity);

            PigLogic newgame = new PigLogic();

            TextView player1 = FindViewById<TextView>(Resource.Id.player1Text);
            TextView player2 = FindViewById<TextView>(Resource.Id.player2Text);

            string p1 = Intent.Extras.GetString(MainActivity.PLAYER1);
            string p2 = Intent.Extras.GetString(MainActivity.PLAYER2);

            Toast.MakeText(this, "fdsfs", ToastLength.Long).Show();

            player1.Text = p1;
            player2.Text = p2;

        }

      


    }
}