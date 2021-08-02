using AngleSharp.Html.Dom;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static Parser.IParser;
using MatchesParser;

namespace MathcesParser
{
    public class MathcesParser : IParser<MatchInfo[]>
    {
        public MatchInfo[] Parse(IHtmlDocument document)
        {
            var sites = document
                .QuerySelectorAll("a")
                .Where(item => item.GetAttribute("title") == "H2H stats - match details");
                

            List<string> listSites = new List<string>();

            foreach(var item in sites)
            {
                listSites.Add(item.GetAttribute("Href"));
            }

            var names = document
                .QuerySelectorAll("td.match");

            List<string> listAllNames = new List<string>();

            foreach (var name in names)
            {
                listAllNames.Add(name.QuerySelector("a").TextContent);
            }


            List<MatchInfo> listMatches = new List<MatchInfo>();

            int k = 0;

            for (int i = 0; i < names.Length; i += 2, k++)
            {
                if (!listAllNames[i].Contains("/"))
                {
                    listMatches.Add(new MatchInfo(listAllNames[i] + " VS. " + listAllNames[i + 1], listSites[k]));
                }

            }


            return listMatches.ToArray();
        }

    }
}
