using System;
using System.Collections.Generic;
using Android.Runtime;
using System.Xml;
using System.IO;

namespace Lab4List
{
    public class XmlFileParser
    {
      
        //constants for the xml elements
        public const string ITEM = "item";
        public const string DATE = "date";
        public const string DAY = "day";
        public const string TIME = "time";
        public const string PRED = "pred";
        public const string HIGHLOW = "highlow";

        List<IDictionary<string, object>> tidelist;
        public List<IDictionary<string, object>> TideList { get { return tidelist; } }

        public XmlFileParser (Stream xmlStream)
        {
            tidelist = new List<IDictionary<string, object>>();

            //parsing the xml file and filling the dictionary with tide objects
            using(XmlReader reader = XmlReader.Create(xmlStream))
            {
                JavaDictionary<string, object> item = null;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case ITEM:
                                item = new JavaDictionary<string, object>();
                                break;
                            case DATE:
                                if(reader.Read() && item != null)
                                {
                                    item.Add(DATE, reader.Value.Trim());
                                }
                                break;
                            case DAY:
                                if (reader.Read() && item != null)
                                {
                                    item.Add(DAY, reader.Value.Trim());
                                }
                                break;
                            case TIME:
                                if (reader.Read() && item != null)
                                {
                                    item.Add(TIME, reader.Value.Trim());
                                }
                                break;
                            case PRED:
                                if (reader.Read() && item != null)
                                {
                                    item.Add(PRED, reader.Value.Trim());
                                }
                                break;
                            case HIGHLOW:
                                if (reader.Read() && item != null)
                                {
                                    item.Add(HIGHLOW, reader.Value.Trim());
                                }
                                break;
                        }
                    }
                    else if (reader.Name == ITEM)
                    {
                        tidelist.Add(item);
                        item = null;
                    }
                }
            }


        }

    }
}