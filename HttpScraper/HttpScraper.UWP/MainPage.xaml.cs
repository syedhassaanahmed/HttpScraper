namespace HttpScraper.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new HttpScraper.App());
        }
    }
}
