using AngleSharp.Html.Parser;
using MatchesParser;
using Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Parser.IParser;

namespace TennisParser
{
    class ParserTennisWorker<T> where T : class
    {
        public IParser<T> Parser { get; set; }

        public IParserSettings Settings { get; set; }

        private HtmlLoader loader;

        private string site;

        public ParserTennisWorker(IParser<T> parser, string site)
        {
            this.Parser = parser;

            this.site = site;
        }

        public ParserTennisWorker(IParser<T> parser, string site, IParserSettings settings) : this(parser, site)
        {
            this.Settings = settings;
        }

        public async Task<T> GetMatchStatistics()
        {
            
            //var list = new List<T>();

            /*foreach(var t in sites)
            {
                Settings.BaseUrl = t;

                loader = new HtmlLoader(Settings);

                var source = await loader.GetSource();

                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                list.Add(Parser.Parse(document));
            }*/

            Settings.BaseUrl = site;

            loader = new HtmlLoader(Settings);

            var source = await loader.GetSource();

            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            //list.Add(Parser.Parse(document));

            return Parser.Parse(document);
        }
    }
}
