using System.Text;

namespace HttpScraper.Core.Parsers
{
    public class EveryNthLetterParser : ContentParserBase
    {
        public string GetEveryNthLetter(int n)
        {
            var result = new StringBuilder();
            for (var i = n - 1; i < Content.Length; i += n)
                result.Append(Content[i]);

            return result.ToString();
        }
    }
}
