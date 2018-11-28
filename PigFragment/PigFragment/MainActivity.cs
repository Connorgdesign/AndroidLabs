using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace PigFragment
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        PigLogic newgame;
        EditText player1;
        EditText player2;
        string player1Text;
        string player2Text;
        public const string PLAYER1 = "player1";
        public const string PLAYER2 = "player2";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            newgame = new PigLogic();

            
            Toast.MakeText(this, player1Text, ToastLength.Long).Show();


            var startButton = FindViewById<Button>(Resource.Id.startButton);
            startButton.Click += delegate
            {
                player1 = FindViewById<EditText>(Resource.Id.player_one);
                player2 = FindViewById<EditText>(Resource.Id.player_two);

                player1Text = player1.Text;
                player2Text = player2.Text;

                newgame.player1Name = player1Text;
                newgame.player1Name = player2Text;

                Intent secondActivity = new Intent(this, typeof(SecondActivity));
                secondActivity.PutExtra(PLAYER1, player1Text);
                secondActivity.PutExtra(PLAYER2, player2Text);
                StartActivity(secondActivity);

            };
        }
    }
}