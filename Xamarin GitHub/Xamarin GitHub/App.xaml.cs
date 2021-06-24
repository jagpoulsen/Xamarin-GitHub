using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_GitHub.Presentation.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Xamarin_GitHub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new NavigationPage(new GitHubUserView());
            MainPage = page;
        }

        public static bool IsNetworkAvailable()
        {
            return  Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
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