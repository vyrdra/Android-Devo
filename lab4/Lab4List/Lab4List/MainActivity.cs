using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab4List
{
    [Activity(Label = "Lab4List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var reader = new XmlFileParser(Assets.Open(@"tide.xml"));
            var dataList = reader.TideList;

            
           
        }
    }
}

