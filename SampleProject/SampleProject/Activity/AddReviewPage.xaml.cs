using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SampleProject.App;

namespace SampleProject.Activity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewPage : ContentPage
    {
#pragma warning disable CS0649 // Field 'AddReviewPage.star' is never assigned to, and will always have its default value 0
        private double star;
#pragma warning restore CS0649 // Field 'AddReviewPage.star' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'AddReviewPage._imgId' is never assigned to, and will always have its default value null
        private string _imgId;
#pragma warning restore CS0649 // Field 'AddReviewPage._imgId' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'AddReviewPage._url' is never assigned to, and will always have its default value null
        private string _url;
#pragma warning restore CS0649 // Field 'AddReviewPage._url' is never assigned to, and will always have its default value null
        public AddReviewPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (entrycomment.Text != null)
            {
                var comment = new tbl_comment()
                {
                    comment = entrycomment.Text,
                    cus_id = user_id,
                    user_id = company_id
                };
                await tbl_comment.Insert(comment);
                //var profile = (await App.MobileService.GetTable<tbl_Users>().Where(prof => prof.Id == App.user_id).ToListAsync()).FirstOrDefault();
                //    if (customRattingBar.SelectedStarValue == 1)
                //    {



                //        var users = new tbl_Users()
                //        {
                //            Id = company_id,
                //            first_name = first_name,
                //            last_name = last_name,
                //            email = email,
                //            password = password,
                //            address = address,
                //            contact_number = contact_number,
                //            company_name = company_name,
                //            cover_img = $"{_url}/{_imgId}.jpg",
                //            one_star = star,
                //            two_star = star,
                //            three_star = star,
                //            four_star = star,
                //            five_star = star,
                //            latitude= latitude,
                //            longitude = longitude,
                //            picstr = $"{_imgId}.jpg"
                //        };
                //        await tbl_Users.Update(users);



                //    }
                //    if (customRattingBar.SelectedStarValue == 2)
                //    {



                //        var users = new tbl_Users()
                //        {
                //            Id = company_id,
                //            first_name = first_name,
                //            last_name = last_name,
                //            email = email,
                //            password = password,
                //            address = address,
                //            contact_number = contact_number,
                //            company_name = company_name,
                //            cover_img = $"{_url}/{_imgId}.jpg",
                //            one_star = star,
                //            two_star = star,
                //            three_star = star,
                //            four_star = star,
                //            five_star = star,
                //            latitude = latitude,
                //            longitude = longitude,
                //            picstr = $"{_imgId}.jpg"
                //        };
                //        await tbl_Users.Update(users);



                //    }
                //    if (customRattingBar.SelectedStarValue == 3)
                //    {



                //        var users = new tbl_Users()
                //        {
                //            Id = company_id,
                //            first_name = first_name,
                //            last_name = last_name,
                //            email = email,
                //            password = password,
                //            address = address,
                //            contact_number = contact_number,
                //            company_name = company_name,
                //            cover_img = $"{_url}/{_imgId}.jpg",
                //            one_star = star,
                //            two_star = star,
                //            three_star = star,
                //            four_star = star,
                //            five_star = star,
                //            latitude = latitude,
                //            longitude = longitude,
                //            picstr = $"{_imgId}.jpg"
                //        };
                //        await tbl_Users.Update(users);



                //    }
                //    if (customRattingBar.SelectedStarValue == 4)
                //    {



                //        var users = new tbl_Users()
                //        {
                //            Id = company_id,
                //            first_name = first_name,
                //            last_name = last_name,
                //            email = email,
                //            password = password,
                //            address = address,
                //            contact_number = contact_number,
                //            company_name = company_name,
                //            cover_img = $"{_url}/{_imgId}.jpg",
                //            one_star = star,
                //            two_star = star,
                //            three_star = star,
                //            four_star = star,
                //            five_star = star,
                //            latitude = latitude,
                //            longitude = longitude,
                //            picstr = $"{_imgId}.jpg"
                //        };
                //        await tbl_Users.Update(users);



                //    }
                //    if (customRattingBar.SelectedStarValue == 5)
                //    {



                //        var users = new tbl_Users()
                //        {
                //            Id = company_id,
                //            first_name = first_name,
                //            last_name = last_name,
                //            email = email,
                //            password = password,
                //            address = address,
                //            contact_number = contact_number,
                //            company_name = company_name,
                //            cover_img = $"{_url}/{_imgId}.jpg",
                //            one_star = star,
                //            two_star = star,
                //            three_star = star,
                //            four_star = star,
                //            five_star = star,
                //            latitude = latitude,
                //            longitude = longitude,
                //            picstr = $"{_imgId}.jpg"
                //        };
                //await tbl_Users.Update(users);



                //}
                await DisplayAlert("Info", "Your comment has been added!", "OK");
                entrycomment.Text = null;
                await Navigation.PopModalAsync();

                }
                else
                {
                    await DisplayAlert("Error", "Please leave a comment", "OK");
                    entrycomment.Focus();
                }
            }
        }
    }