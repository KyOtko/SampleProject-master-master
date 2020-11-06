using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using SampleProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var users = (await App.MobileService.GetTable<tbl_Users>().Where(email => email.email == emailEntry.Text).ToListAsync()).FirstOrDefault();
            if (users != null)
            {
                if (users.password == passwordEntry.Text)
                {
                    await DisplayAlert("Found", "Email and password match!", "OK");
                    await Navigation.PushAsync(new MainMenuPage());
                }
                else
                {
                    await DisplayAlert("Error", "Email and password did not match!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Email not found!", "OK");
            }
        }

        private async void Btnsignup_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
//var users = (await MobileService.GetTable<TBL_Users>().Where(mail => mail.emailadd == emailentry.Text).ToListAsync()).FirstOrDefault();
//if (users != null)
//{
//if (users.password == passentry.Text)
//{
//    user_id = users.Id;
//    //await DisplayAlert("Success", "Email or password is incorrect!", "OK");
//    Device.BeginInvokeOnMainThread(() =>
//    {
//        Application.Current.MainPage = new AppShell();
//    });
//    await Navigation.PushAsync(new MenuPage(), true);
//}
//else
//{
//    indicatorloader.IsVisible = false;
//    await DisplayAlert("Error", "Email or password is incorrect!", "OK");
//}
//}
//else
//{
//indicatorloader.IsVisible = false;
//await DisplayAlert("Error", "There was an error logging you in! Please check the information you're entering.", "OK");
//}



//******************************
//public string Id { get; set; }
//public string full_name { get; set; }
//public string mobile_num { get; set; }
//public string emailadd { get; set; }
//public string password { get; set; }
//public DateTime datereg { get; set; }