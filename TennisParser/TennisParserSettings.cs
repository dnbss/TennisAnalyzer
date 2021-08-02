using Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace TennisParser.CoreParser.Tennis
{
    class TennisParserSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "";

        public string Prefix { get; set; } = "";
    }
}
