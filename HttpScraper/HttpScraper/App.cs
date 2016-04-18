using HttpScraper.ViewModels;
using HttpScraper.Views;
using System.Threading;
using Xamarin.Forms;

namespace HttpScraper
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
            ViewModelBase.Context = SynchronizationContext.Current;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
