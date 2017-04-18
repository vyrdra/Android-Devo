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

namespace _99bugs
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

        int bugs = 99;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Second);
            
            int bugsRand = Intent.Extras.GetInt(FirstActivity.EXTRA_BUGS);
            
            var bugLbl = FindViewById<TextView>(Resource.Id.bugLbl);
            
            bugLbl.Text = bugsRand.ToString();
             
            Button patchBtn = FindViewById<Button>(Resource.Id.patchBtn);
            patchBtn.Click += delegate
            {
                
                var first = new Intent(this, typeof(FirstActivity));
                int total = BugNum(bugsRand);
                first.PutExtra(FirstActivity.EXTRA_NEW, total);
                SetResult(Result.Ok, first);
                Finish();
            };
        }



        protected int BugNum(int i)
        {
            int b = i % 2;

            if (b == 0)
            {
                bugs += i; 
            }
            else
            {
                bugs -= 1;
            }
            return bugs;
        }

    }
}