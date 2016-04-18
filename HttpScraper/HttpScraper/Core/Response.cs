using HttpScraper.Core.Parsers;
using System;

namespace HttpScraper.Core
{
    public class Response<TContentParser> where TContentParser : ContentParserBase
    {
        public TContentParser ContentParser { get; private set; }
        public bool IsSuccessStatusCode { get; private set; }

        public Response() : this(default(TContentParser), false) { }

        public Response(TContentParser contentParser, bool isSuccessStatusCode)
        {
            ContentParser = contentParser;
            IsSuccessStatusCode = isSuccessStatusCode;
        }

        public Response<TContentParser> OnSuccess(Action<TContentParser> action)
        {
            if (IsSuccessStatusCode)
                action(ContentParser);

            return this;
        }

        public Response<TContentParser> OnFailure(Action action)
        {
            if (!IsSuccessStatusCode)
                action();

            return this;
        }
    }
}
