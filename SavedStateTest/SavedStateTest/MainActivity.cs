using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace SavedStateTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        const string COUNTER_KEY = "Counter";
        TextView numberText;
        Number n;
        int count;
        string number;
        int Count;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            

            numberText = FindViewById<TextView>(Resource.Id.numberTextView);

            var countButton = FindViewById<Button>(Resource.Id.countButton);

            var resetButton = FindViewById<Button>(Resource.Id.resetButton);

            ShowCount();

            if (bundle != null)
            {
                Count = bundle.GetInt(COUNTER_KEY, -1);

                if (Count > 0)
                {
                    count = Count;
                    ShowCount();
                    n = new Number(number, count);
                    Toast.MakeText(this, count.ToString(), ToastLength.Long).Show();
                    // only use the saved count if it has been incremented at least once
                    //Toast.MakeText(this, savedCount, ToastLength.Long).Show();              
                }
            }

            else {
                //count = 0;
                //number = "0";
                n = new Number();
            }      

            countButton.Click += delegate
            {
          
                count = n.increaseNumber();
                Toast.MakeText(this, count.ToString(), ToastLength.Long).Show();
                ShowCount();

            };

            resetButton.Click += delegate
            {

                numberText.Text = n.resetNumber();

            };

        }

        private void ShowCount() {
            numberText.Text = count.ToString();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(COUNTER_KEY, count);
        }

        


    }
}