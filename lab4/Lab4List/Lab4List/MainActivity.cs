using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Runtime;
using System;

namespace Lab4List
{
    [Activity(Label = "Lab4List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var reader = new XmlFileParser(Assets.Open(@"tide_annual.xml"));
            var dataList = reader.TideList;


            //sorting by date and time
            dataList.Sort((x, y) => string.Compare((string)x[XmlFileParser.DATE] + (string)x[XmlFileParser.TIME],
                (string)y[XmlFileParser.DATE] + (string)y[XmlFileParser.TIME], StringComparison.Ordinal));

           


            ListAdapter = new TideAdapter(this, dataList, Android.Resource.Layout.SimpleListItem2,
                new string[] { XmlFileParser.FIRSTLINE, XmlFileParser.SECONDLINE},
                new int[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 }
                );

            

            ListView.FastScrollEnabled = true;

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            string prediction = (string)((JavaDictionary<string, object>)ListView.GetItemAtPosition(position))[XmlFileParser.PREDFT];

            Android.Widget.Toast.MakeText(this, "Tide: " + prediction + " ft.", ToastLength.Short).Show();
        }

    }
}

