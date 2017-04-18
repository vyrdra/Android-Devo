using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Runtime;

namespace _99bugs
{

    [Activity(Label = "_99bugs", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity : Activity
    {
        public const string EXTRA_BUGS = "Bugs";
        public const string EXTRA_NEW = "New Bugs";
        public const string EXTRA_TOSEC = "ToSecond";
        int total = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.First);

            Random r = new Random();
            
            

            Button bug1Btn = FindViewById<Button>(Resource.Id.oneBug);
            bug1Btn.Click += delegate
            {
                var second = new Intent(this, typeof(SecondActivity));
                int bugNum1 = r.Next(1, 50);
                second.PutExtra(EXTRA_BUGS, bugNum1);
                StartActivityForResult(second, 0);
            };
            Button bug2Btn = FindViewById<Button>(Resource.Id.twoBug);
            bug2Btn.Click += delegate
            {
                var second = new Intent(this, typeof(SecondActivity));
                int bugNum2 = r.Next(1, 100);
                second.PutExtra(EXTRA_BUGS, bugNum2);
                StartActivityForResult(second, 0);
            };
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
                {
                    total = data.GetIntExtra(EXTRA_NEW, -1);
                    if(total != -1)
                    {
                        var resultLbl = FindViewById<TextView>(Resource.Id.resultLbl);
                        resultLbl.Text = string.Format("{0} little bugs in the code, hahaha.", total);
                        
                    }
                    
                }
            
        }

    }
}

