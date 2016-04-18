using HttpScraper.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HttpScraper.Core.Parsers
{
    public class WordCountParser : ContentParserBase
    {
        public IEnumerable<WordCountItem> GetWordCount()
        {
            //Split by whitespaces, obtain count for each word, sort by count descending, create dictionary
            return Regex.Split(Content, @"\s+")
                .GroupBy(w => w, (x, y) => new WordCountItem { Word = x, Count = y.Count() })
                .OrderByDescending(w => w.Count);
        }
    }
}
