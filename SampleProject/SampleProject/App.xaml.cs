using System;
using Microsoft.WindowsAzure.MobileServices;
using SampleProject.Activity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleProject
{
    public partial class App : Application
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://imarketresource.azurewebsites.net");
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Activity.StackLayout());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
