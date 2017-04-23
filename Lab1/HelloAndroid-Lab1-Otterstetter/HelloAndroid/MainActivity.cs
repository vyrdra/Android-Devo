using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloAndroid
{
    [Activity(Label = "HelloAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //create the user interface in code
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            TextView aLabel = new TextView(this);
            TextView Label2 = new TextView(this);
            aLabel.Text = "Hello, Xamarin Android";
            Label2.Text = "---";

            Button aButton = new Button(this);
            Button Button2 = new Button(this);
            aButton.Text = "Say Hello";
            Button2.Text = "Clear";
            aButton.Click += (sender, e) => 
                { Label2.Text = "Hello from the button again"; };
            Button2.Click += (sender, e) => { aLabel.Text = ""; Label2.Text = ""; };

            layout.AddView(aLabel);
            layout.AddView(Label2);
            layout.AddView(aButton);
            layout.AddView(Button2);
            SetContentView(layout);
        }
    }
}

