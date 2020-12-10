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
        protected override void OnAppearing()
        {
            Loadcategories();
        }

        private async void Loadcategories()
        {
            var categories = await tbl_Categories.Read();
            categorylist.ItemsSource = categories;
        }
    }
}