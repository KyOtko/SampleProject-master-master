using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SampleProject.App;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProfPage : ContentPage
    {
        public ViewProfPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                //progressload.IsVisible = true;
                var profile = (await MobileService.GetTable<tbl_Users>().Where(prof => prof.Id == company_id).ToListAsync()).FirstOrDefault();
                profilegrid.BindingContext = profile;
                //progressload.IsVisible = false;
            }
            catch
            {
                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
                //progressload.IsVisible = false;
            }
        }
    }
}