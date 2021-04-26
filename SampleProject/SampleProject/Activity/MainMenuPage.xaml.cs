using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
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
            //new MenuShell();
        }

        protected override async void OnAppearing()
        {
            await Loadcategories();
            await Loadcompanies();
            //await GetSections();
        }

        private async Task Loadcategories()
        {
            RefreshView.IsRefreshing = true;
            var categories = await tbl_Categories.Read();
            categorylist.ItemsSource = categories;
            RefreshView.IsRefreshing = false;
        }

        private async Task Loadcompanies()
        {
            RefreshView.IsRefreshing = true;
           // var Users = await tbl_Users.Read();
            var userC = await tbl_Users.Read();
            ListCompanies.ItemsSource = userC;
            RefreshView.IsRefreshing = false;
        }

        private async Task XSearch(string query)
        {
            try
            {
                var userC = (await App.MobileService.GetTable<tbl_Users>().ToListAsync());
                ListCompanies.ItemsSource = userC.Where(p => p.company_name.ToLower().Contains(query.ToLower())).ToList();
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
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
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == true)
            {
                if (ListCompanies.SelectedItem == null) return;
                App.company_id = (e.CurrentSelection.FirstOrDefault() as tbl_Users)?.Id;
                await Navigation.PushAsync(new ViewProfPage(), true);
            }
            else
            {
                await Navigation.PushAsync(new NoInternetPage());
            }
            //if (ListCompanies.SelectedItem == null) return;
            ////try
            ////{
            //    App.company_id = (e.CurrentSelection.FirstOrDefault() as tbl_Users)?.Id;
            //    await Navigation.PushAsync(new ViewProfPage(), true);
            //}
            //catch
            //{
            //    App.company_id = (e.CurrentSelection.FirstOrDefault() as tbl_Users)?.Id;
            //    await Navigation.PushAsync(new ViewProfPage(), true);
            //}
        
        }
        

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async void categoryList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            //    if (categorylist.SelectedItem == null) return;
            //    var cat_name = (e.CurrentSelection.FirstOrDefault() as tbl_Categories)?.cat_name;
            //    await GetSections(cat_name);
        }

        private async Task GetSections(string cat)
        {

           // RefreshView.IsRefreshing = true;
            var usersc = (await App.MobileService.GetTable<tbl_Users>().ToListAsync());
            ListCompanies.ItemsSource = usersc.Where(p => p.cat_name.ToLower().Contains(cat.ToLower())).ToList();
            RefreshView.IsRefreshing = false;


        }

        private async void Categorylist_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected == true)
            {
                if (categorylist.SelectedItem == null) return;
                var cat = (e.CurrentSelection.FirstOrDefault() as tbl_Categories)?.cat_name;
                await GetSections(cat);
            }
            else
            {
                await Navigation.PushAsync(new NoInternetPage());
            }
            //  if (categorylist.SelectedItem == null) return;
            

            //    var cat_name = (e.CurrentSelection.FirstOrDefault() as tbl_Categories)?.cat_name;
            //    await GetSections(cat_name);

            //var cat = (e.CurrentSelection.FirstOrDefault() as tbl_Categories)?.cat_name;
            // await Navigation.PushAsync(new ViewProfPage(), true);
            // if (categorylist.SelectedItem == cat)
            // {
            //var getcats = await App.MobileService.GetTable<tbl_Users>().Where(c => c.cat_name.ToLower().Contains(cat.ToLower())).ToListAsync();
            //    categorylist.ItemsSource = getcats;
            //}

            // await GetSections(cat);



            //var Users = (await App.MobileService.GetTable<tbl_Users>().ToListAsync());
            //ListUsers.ItemsSource = Users.Where(p => p.company_name.ToLower().Contains(query.ToLower())).ToList();
        }


        private async void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            await Loadcompanies();
        }
    }
}
    