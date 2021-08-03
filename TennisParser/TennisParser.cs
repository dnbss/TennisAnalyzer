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

            int number = items.Length;

            var last = items
                .Last();

            var matchPoints = last
                    .QuerySelectorAll("td")
                    .Where(item => item.ClassName == "mp_15" || item.ClassName == "mp_info_txt");

            List<Set<string>> sets = new List<Set<string>>();

            sets.Add(TennisConverter.ConvertToSet(matchPoints, number));

            /*foreach (var set in items)
            {
                var matchPoints = set
                    .QuerySelectorAll("td")
                    .Where(item => item.ClassName == "mp_15" || item.ClassName == "mp_info_txt");

                sets.Add(TennisConverter.ConvertToSet(matchPoints));
            }
*/

            return sets.ToArray();
        }
    }
}
