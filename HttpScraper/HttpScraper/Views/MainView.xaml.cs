
using HttpScraper.ViewModels;
using System;
using Xamarin.Forms;

namespace HttpScraper.Views
{
    public partial class MainView : TabbedPage
    {
        MainViewModel ViewModel { get; } = new MainViewModel();

        public MainView()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        async void OnStartClicked(object sender, EventArgs args)
        {
            await ViewModel.StartAsync();
        }
    }
}
