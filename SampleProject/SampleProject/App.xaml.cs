using System;
using SampleProject.Activity;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleProject
{
    public partial class App : Application
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://lookappinstance.azurewebsites.net");
        public static string company_id, cus_id;
        public static string user_id, full_name, Id, comment;
        public static string first_name, cat_name, cat_img, last_name, datereg, email, password, propic, address, contact_number, company_name, cover_img, listing, city, bIrimg, picstr;
        public static double one_star, two_star, three_star, four_star, five_star, ratings, tot_rate;
        public static double latitude;
        public static double longitude;
 

        public App()
        {
            InitializeComponent();
            MainPage=new NavigationPage(new Activity.LoginPage());
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
