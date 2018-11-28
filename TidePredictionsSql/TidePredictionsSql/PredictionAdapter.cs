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

namespace TidePredictionsSql
{
    class PredictionAdapter : SimpleAdapter, ISectionIndexer
    {
        List<IDictionary<string, object>> List;
        String[] sections;

        Java.Lang.Object[] sectionsObjects;
        Dictionary<string, int> getMonth;

        public PredictionAdapter(Context context,
            List<IDictionary<string, object>> data,
            Int32 resource, String[] from,
            Int32[] to) : base(context, data, resource, from, to)
        {
            List = data;

            List.Sort((x, y) => String.Compare((string)x[XmlTideFileParser.DAY], (string)y[XmlTideFileParser.DAY]));
            BuildSectionIndex();
        }



        public int GetPositionForSection(int section)
        {
            return getMonth[sections[section]];
        }

        public int GetSectionForPosition(int position)
        {
            return 1;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionsObjects;
        }

        private void BuildSectionIndex()
        {
            getMonth = new Dictionary<string, int>();
            for (var i = 0; i < Count; i++)
            {

                var key = (string)List[i][XmlTideFileParser.DATE];
                if (!getMonth.ContainsKey(key))
                {
                    getMonth.Add(key, i);
                }
            }

            sections = new string[getMonth.Keys.Count];
            getMonth.Keys.CopyTo(sections, 0);


            sectionsObjects = new Java.Lang.Object[sections.Length];
            for (var i = 0; i < sections.Length; i++)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }
    }
}