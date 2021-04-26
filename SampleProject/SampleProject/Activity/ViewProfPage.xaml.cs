using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SampleProject.App;


namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProfPage : ContentPage

    {
#pragma warning disable CS0649 // Field 'ViewProfPage.lat' is never assigned to, and will always have its default value 0
        private double lat;
#pragma warning restore CS0649 // Field 'ViewProfPage.lat' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'ViewProfPage.lng' is never assigned to, and will always have its default value 0
        private double lng;
#pragma warning restore CS0649 // Field 'ViewProfPage.lng' is never assigned to, and will always have its default value 0

        public ViewProfPage()
        {
            InitializeComponent();
            //Map.PropertyChanged += Map_PropertyChanged;
        }

        protected override async void OnAppearing()
        {
           await XGetDetails();
            //await detCat();
            await GetDirect();

        }

        private async Task XGetDetails()
        {
            //try
            //{
            //progressload.IsVisible = true;
            var profile =
                (await MobileService.GetTable<tbl_Users>().Where(prof => prof.Id == company_id).ToListAsync())
                .FirstOrDefault();
            profilegrid.BindingContext = profile;
            //lat = profile.latitude;
            //lng = profile.longitude;
            //full_name = profile.
            one_star = profile.one_star;
            two_star = profile.two_star;
            three_star = profile.three_star;
            four_star = profile.four_star;
            five_star = profile.five_star;
            first_name = profile.first_name;
            last_name = profile.last_name;
            address = profile.address;
            contact_number = profile.contact_number;
            email = profile.email;
            company_name = profile.company_name;
            password = profile.password;
            datereg = profile.datereg;
            cover_img = profile.cover_img;
            listing = profile.listing;
            city = profile.city;
           cat_name = profile.cat_name;
            bIrimg = profile.birImg;
            propic = profile.propic;
            picstr = profile.picstr;
            //progressload.IsVisible = false;

            //double rating =
            //    (5 * five_star + 4 * four_star + 3 * three_star + 2 * two_star + 1 * one_star) /
            //    (one_star + two_star + three_star + four_star + five_star);

            //rating = Math.Round(rating, 1);

            // ratingOP.Text = rating.ToString();

            //this.ratingOP.Precision = Syncfusion.Windows.Forms.Tools.PrecisionMode.Half;
            //rating = double.Parse(customRattingBar.SelectedStarValue.ToString());
            //RefreshView.IsRefreshing = true;
            var getComments = await MobileService.GetTable<CommentView>().Where(u => u.user_id == comment)
                .ToListAsync();
            //await MobileService.GetTable<CommentView>().Where(users_Id => users_Id.id == cus_id).ToListAsync();
            ListComment.ItemsSource = getComments;
            //var getCommentss = await MobileService.GetTable<CommentView>().Where(usersId => usersId.full_name == company_id).ToListAsync();
            //ListComment.ItemsSource = getCommentss;
            RefreshView.IsRefreshing = false;
            //}
            //catch
            //{
            //    await DisplayAlert("Network Error",
            //        "A network error occured, please check your internet connectivity and try again.", "OK");
            //    //progressload.IsVisible = false;
            //}
        }

        //private async Task detCat()
        //{
        //    var usrcat =
        //        (await App.MobileService.GetTable<tbl_userCat>().Where(br => br.user_id == App.company_id)
        //            .ToListAsync()).FirstOrDefault();
        //    profilegrid.BindingContext = usrcat;
        //    cover_img = usrcat.cover_img;

           
        //}

        private async Task GetDirect()
        {
            try
            {
                var mapps =
                    (await App.MobileService.GetTable<tbl_map>().Where(br => br.user_id == App.company_id)
                        .ToListAsync()).FirstOrDefault();
                lat = mapps.latitude;
                lng = mapps.longitude;

                //RefreshView.IsRefreshing = true;
                //var getComments = await MobileService.GetTable<CommentView>().Where(u => u.user_id == company_id)
                //    .ToListAsync();
                ////await MobileService.GetTable<CommentView>().Where(users_Id => users_Id.id == cus_id).ToListAsync();
                //ListComment.ItemsSource = getComments;
                ////var getCommentss = await MobileService.GetTable<CommentView>().Where(usersId => usersId.full_name == company_id).ToListAsync();
                ////ListComment.ItemsSource = getCommentss;
                //RefreshView.IsRefreshing = false;
            }
            catch
            {
                //await DisplayAlert("Network Error",
                //  "A network error occured, please check your internet connectivity and try again.", "OK");
            }


        }

        private async void Getdirection_OnClicked(object sender, EventArgs e)
        {
            //if (!double.TryParse(EntryLatitude.Text, out double lat))
            //    return;
            //if (!double.TryParse(EntryLongitude.Text, out double lng))
            //return;

            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                //Name = EntryName.Text,

                NavigationMode = NavigationMode.Driving
            });
        }

        private async void Addcomment_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddReviewPage());
            await XGetDetails();
        }

        //private async Task LoadData()
        //{
        //    var getcomment = (await MobileService.GetTable<tbl_comment>().Where(p => p.id == user_id).ToListAsync()).FirstOrDefault();
        //    this.BindingContext = getcomment;
        //}


        private async void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            await GetDirect();
            await XGetDetails();
        }

        //private async void Birshow_OnClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new birPage());
        //}
        private async void Birshow_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new birPage());
        }
    }
}