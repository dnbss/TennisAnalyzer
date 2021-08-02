using System;
using System.Collections.Generic;
using System.Text;

namespace MatchesParser
{
    public class MatchInfo
    {
        public readonly string Name;

        public readonly string Url;

        public MatchInfo(string name, string url)
        {
            Name = name;

            Url = url;
        }
    }
}
