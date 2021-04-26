using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class birPage : ContentPage
    {
        public birPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await Loadbirimage();
        }
        private async Task Loadbirimage()
        {

            var bir =
                (await App.MobileService.GetTable<tbl_bir>().Where(prof => prof.user_id == App.company_id)
                    .ToListAsync());
            BIRIMG.ItemsSource = bir;

        }
    }

}