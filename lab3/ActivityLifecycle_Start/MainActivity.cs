namespace ActivityLifecycle
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Util;
    using Android.Widget;

    [Activity(Label = "Activity A", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
			Log.Debug(GetType().FullName, "Activity A - OnCreate");
			base.OnCreate(bundle);
			SetContentView (Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.myButton).Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(SecondActivity));
                StartActivity(intent);
            };

            if(bundle != null)
            {
                counter = bundle.GetInt("click_count", 0);
                Log.Debug(GetType().FullName, "Activity A - Recovered instance state");
            }
            var clickButton = FindViewById<Button>(Resource.Id.clickBtn);
            clickButton.Text = Resources.GetString(
                Resource.String.counterbutton_text, counter);
            clickButton.Click += (object sender, System.EventArgs e) =>
            {
                counter++;
                clickButton.Text = Resources.GetString(
                    Resource.String.counterbutton_text, counter);
            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("click_count", counter);
            Log.Debug(GetType().FullName, "Activity A - Saving instance state");

            base.OnSaveInstanceState(outState);
        }

        protected override void OnDestroy()
        {
            Log.Debug(GetType().FullName, "Activity A - On Destroy");
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            Log.Debug(GetType().FullName, "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnRestart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnRestart");
            base.OnRestart();
        }

        protected override void OnResume()
        {
            Log.Debug(GetType().FullName, "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnStart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnStop()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStop");
            base.OnStop();
        }
    }
}
