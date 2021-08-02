using Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchesParser
{
    public class MathcesSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = $"https://www.tennislive.net";

        public string Prefix { get; set; } = "";
    }
}
