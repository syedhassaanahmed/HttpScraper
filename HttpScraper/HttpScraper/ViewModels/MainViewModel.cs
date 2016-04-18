using HttpScraper.Core;
using HttpScraper.Core.Models;
using HttpScraper.Core.Parsers;
using HttpScraper.Strings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpScraper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        string _nthLetter;
        public string NthLetter
        {
            get { return _nthLetter; }
            set { Set(ref _nthLetter, value); }
        }

        string _everyNthLetter;
        public string EveryNthLetter
        {
            get { return _everyNthLetter; }
            set { Set(ref _everyNthLetter, value); }
        }

        IEnumerable<WordCountItem> _wordCount;
        public IEnumerable<WordCountItem> WordCount
        {
            get { return _wordCount; }
            set { Set(ref _wordCount, value); }
        }

        string _wordCountError;
        public string WordCountError
        {
            get { return _wordCountError; }
            set { Set(ref _wordCountError, value); }
        }

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        void ClearAll()
        {
            NthLetter = string.Empty;
            EveryNthLetter = string.Empty;
            WordCount = null;
            WordCountError = string.Empty;
        }

        public async Task StartAsync()
        {
            if (IsLoading)
                return;

            IsLoading = true;
            ClearAll();

            try
            {
                await RunRequestsAsync();
            }
            finally
            {
                IsLoading = false;
            }
        }

        async Task RunRequestsAsync()
        {
            var request = new Request("http://www.google.com");

            await Task.WhenAll
            (
                request.RunAsync<NthLetterParser>().ContinueWith(t => t.Result
                    .OnSuccess(p => NthLetter = p.GetNthLetter(20))
                    .OnFailure(() => NthLetter = Resources.RequestError)),

                request.RunAsync<EveryNthLetterParser>().ContinueWith(t => t.Result
                    .OnSuccess(p => EveryNthLetter = p.GetEveryNthLetter(10))
                    .OnFailure(() => EveryNthLetter = Resources.RequestError)),

                request.RunAsync<WordCountParser>().ContinueWith(t => t.Result
                    .OnSuccess(p => WordCount = p.GetWordCount())
                    .OnFailure(() => WordCountError = Resources.RequestError))
            );
        }
    }
}
