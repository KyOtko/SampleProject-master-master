using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuShell : Shell
    {
        public MenuShell()
        {
            InitializeComponent();
            //RegisterRoutes();
            BindingContext = this;
        }

        private async void ItemUser_OnClicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
           // await DisplayAlert("Notification", "Email and password did not match!", "OK");
            await Navigation.PushModalAsync(new LoginPage());
        }
        //public ICommand ExecuteLogout => new Command(() => this.DisplayAlert("Logged Out", null, "ok"));
        

        //public ICommand ExecuteLogout => new Command(async () => await GoToAsync(LoginPage));
        //private ShellNavigationState LoginPage { get; }


        //var nav = new NavigationPage(new MainMenuPage());
        //MainMenuPage = nav;
    }
}