using System;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using Java.Lang;

namespace Lab4List
{
    public class TideAdapter : SimpleAdapter, ISectionIndexer
    {
        List<IDictionary<string, object>> tideList;
        System.String[] sections;
        Java.Lang.Object[] sectionObjects;
        Dictionary<string, int> monthIndex;

        public TideAdapter(Context ctx, List<IDictionary<string, object>> data, Int32 resource, System.String[] from, Int32[] to) 
            : base(ctx, data, resource, from, to)
        {
            tideList = data;
            BuildSectionIndex();
        }





        public int GetPositionForSection(int sectionIndex)
        {
            return monthIndex[sections[sectionIndex]];
        }

        public int GetSectionForPosition(int position)
        {
            return 1;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionObjects;
        }

        private void BuildSectionIndex()
        {
            monthIndex = new Dictionary<string, int>();
            for (int i = 0; i < Count; i++)
            {
                //get the date string
                string date = (string)tideList[i][XmlFileParser.DATE];
                //use substring to get month
                string key = date.Substring(5, 2);

                if (!monthIndex.ContainsKey(key))
                {
                    monthIndex.Add(key, i);
                }
            }

            //get the number of sections
            sections = new string[monthIndex.Keys.Count];
            //copy section names into the sections array
            monthIndex.Keys.CopyTo(sections, 0);

            //now put them into a Java array
            sectionObjects = new Java.Lang.Object[sections.Length];
            for (int i = 0; i < sections.Length; i++)
            {
                sectionObjects[i] = new Java.Lang.String(sections[i]);
            }
        }
    }
}