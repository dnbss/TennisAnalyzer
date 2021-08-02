using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennis;
using static Parser.IParser;

namespace TennisParser
{
    class TennisParser : IParser<Set<string>[]>
    {
        public Set<string>[] Parse(IHtmlDocument document)
        {

            var items = document
                .QuerySelectorAll("table.table_stats_match");

            List<Set<string>> sets = new List<Set<string>>();

            foreach(var set in items)
            {
                var matchPointsInfo = set
                    .QuerySelectorAll("td.mp_info_txt")
                    .Select(item => item.TextContent);

                var matchPoints15 = set
                    .QuerySelectorAll("td.mp_15")
                    .Select(item => item.TextContent);

                sets.Add(TennisConverter.TennisConverter.ConvertToSet(matchPointsInfo.ToList(), matchPoints15.ToList()));
            }


            return sets.ToArray();
        }
    }
}
