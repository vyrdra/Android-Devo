using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloAndroid.XML
{
    [Activity(Label = "HelloAndroid.XML", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var aButton = FindViewById<Button>(Resource.Id.aButton);
            var aLabel = FindViewById<TextView>(Resource.Id.aLabel);
            var aLabel2 = FindViewById<TextView>(Resource.Id.aLabel2);
            var clearButton = FindViewById<Button>(Resource.Id.clearButton);

            aButton.Click += (sender, e) => 
                { aLabel2.Text = "Hello from the button"; };
            clearButton.Click += (sender, e) => { aLabel.Text = ""; aLabel2.Text = ""; };

        }
    }
}

