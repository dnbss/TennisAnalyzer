using Parser;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class HtmlLoader
    {
        private HttpClient client;

        private string url;

        public HtmlLoader(IParserSettings parserSetting)
        {
            client = new HttpClient();

            url = parserSetting.BaseUrl + parserSetting.Prefix;
        }

        public async Task<string> GetSource()
        {
            var response = await client.GetAsync(url);

            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

    }
}
