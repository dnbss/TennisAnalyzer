using AngleSharp.Html.Parser;
using Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Parser.IParser;

namespace MatchesParser
{
    public class ParserMatchesWorker<T> where T : class
    {
        public IParser<T> Parser { get; set; }

        public IParserSettings Settings { get; set; }

        private HtmlLoader loader;

        public ParserMatchesWorker(IParser<T> parser)
        {
            this.Parser = parser;

        }

        public ParserMatchesWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            this.Settings = settings;
        }

        public async Task<T> GetMatches()
        {
            loader = new HtmlLoader(Settings);

            var source = await loader.GetSource();

            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            return Parser.Parse(document);

        }
    }
}
