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
        private async Task XSearch(string query)
        {
            try
            {
                var Users = (await App.MobileService.GetTable<tbl_Users>().ToListAsync());
                ListUsers.ItemsSource = Users.Where(p => p.company_name.ToLower().Contains(query.ToLower())).ToList();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }

        }

        private async void Prosearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            await XSearch(prosearch.Text);

        }

        private async void ListUsers_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUsers.SelectedItem == null) return;
            App.company_id = (e.CurrentSelection.FirstOrDefault() as tbl_Users)?.Id;
            await Navigation.PushAsync(new ViewProfPage(), true);
        }
    }
}