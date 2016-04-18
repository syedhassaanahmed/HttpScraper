namespace HttpScraper.Core.Parsers
{
    public class NthLetterParser : ContentParserBase
    {
        public string GetNthLetter(int n)
        {
            return Content.Length >= n ? Content[n - 1].ToString() : string.Empty;
        }
    }
}
