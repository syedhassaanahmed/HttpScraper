using HttpScraper.Core.Parsers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpScraper.Core
{
    public class Request
    {
        public string Url { get; private set; }

        public Request(string url)
        {
            Url = url;
        }

        public async Task<Response<TContentParser>> RunAsync<TContentParser>()
            where TContentParser : ContentParserBase, new()
        {
            await Task.Delay(2000);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(new Uri(Url));

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentParser = new TContentParser { Content = await httpResponse.Content.ReadAsStringAsync() };
                    return new Response<TContentParser>(contentParser, true);
                }

                return new Response<TContentParser>();
            }
        }
    }
}
