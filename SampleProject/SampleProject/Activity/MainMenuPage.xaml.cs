using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleProject.Model;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await Loadcategories();
            await LoadUsers();
        }

        private async Task Loadcategories()
        {
            var categories = await tbl_Categories.Read();
            categorylist.ItemsSource = categories;
        }
        private async Task LoadUsers()
        {
            var Users = await tbl_Users.Read();
            ListUsers.ItemsSource = Users;
        }
    }
}