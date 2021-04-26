using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Connectivity;
using Xamarin.Essentials;
using SampleProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SampleProject.App;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (loadingindicator.IsVisible) return;
                loadingindicator.IsVisible = true;
                var users = (await App.MobileService.GetTable<tbl_Costumer>().Where(email => email.email == emailEntry.Text).ToListAsync()).FirstOrDefault();
                if (users != null)
                {
                    if (users.password == passwordEntry.Text)
                    {
                        company_id = users.id;
                        full_name = users.full_name;
                        email = users.email;
                        password = users.password;
                        //App.address = users.address;
                        //App.contact_number = users.contact_number;
                        //App.company_name = users.company_name;
                        //App.cover_img = users.cover_img;
                        //App.listing = users.listing;
                        //App.city = users.city;
                        //App.bIrimg = users.birImg;
                        //App.cat_name = users.cat_name;
                        //App.picstr = users.picstr;
                        //App.email = users.email;
                        //App.password = users.password;
                        loadingindicator.IsVisible = true;
                        loadingindicator.IsVisible = false;
                        //await Navigation.PushAsync(new MainMenuPage());
                        Application.Current.MainPage = new NavigationPage(new MainMenuPage());
                    }
                    else
                    {
                        loadingindicator.IsVisible = false;
                        await DisplayAlert("Error", "Email and password did not match!", "OK");
                    }
                }
                else
                {
                    loadingindicator.IsVisible = false;
                    await DisplayAlert("Error", "Email not found!", "OK");
                }
            }
            catch
            {
                loadingindicator.IsVisible = false;
                await Navigation.PushAsync(new NoInternetPage());
            }
            //var users = (await App.MobileService.GetTable<tbl_Costumer>().Where(email => email.email == emailEntry.Text).ToListAsync()).FirstOrDefault();
            //if (users != null)
            //{
            //    if (users.password == passwordEntry.Text)
            //    {
            //        App.user_id = users.id;
            //        Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage = new MenuShell(); });
            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", "Email and password did not match!", "OK");
            //    }
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Email not found!", "OK");
            //}
        }

        private async void Btnsignup_OnClicked(object sender, EventArgs e)
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == true)
            {
                await Navigation.PushAsync(new SignupPage());
            }
            else
            {
                await Navigation.PushAsync(new NoInternetPage());
            }
        }

        private void EmailEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            var email = emailEntry.Text;

            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(email, emailPattern))
            {

                lblerror.IsVisible = false;
            }
            else
            {

                lblerror.IsVisible = true;
            }
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