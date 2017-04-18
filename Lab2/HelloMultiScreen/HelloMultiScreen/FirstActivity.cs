using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace HelloMultiScreen
{
    [Activity(Label = "HelloMultiScreen", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.First);

            var showSecond = FindViewById<Button>(Resource.Id.showSecond);
            showSecond.Click += (sender, e) =>
            {
                var second = new Intent(this, typeof(SecondActivity));
                second.PutExtra("FirstData", "Data from FirstActivity");
                StartActivity(second);
            };
        }
    }
}

