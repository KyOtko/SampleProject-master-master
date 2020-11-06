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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entry_fname.Text == null)
                {
                await DisplayAlert("Field required", "Please enter you full name!", "OK");
                entry_fname.Focus();
                return;
                }

            if (entry_lname.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                entry_lname.Focus();
                return;
            }

            if (Address.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                Address.Focus();
                return;
            }

            if (contact_Num.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                contact_Num.Focus();
                return;
            }

            if (entry_email.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                entry_email.Focus();
                return;
            }

            if (dob.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                dob.Focus();
                return;
            }

            if (entry_gender.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                entry_gender.Focus();
                return;
            }

            if (entry_pword.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                entry_pword.Focus();
                return;
            }

            if (entry_cpword.Text == null)
            {
                await DisplayAlert("Field required", "Please enter you mobile number.", "OK");
                entry_cpword.Focus();
                return;
            }
            if (entry_pword.Text == entry_cpword.Text)
            {
                var user = new tbl_Users
                {
                    first_name=entry_fname.Text,
                    last_name=entry_lname.Text,
                    address=Address.Text,
                    contact_number=contact_Num.Text,
                    dob=dob.Text,
                    gender=entry_gender.Text,
                    email=entry_email.Text,
                    password=entry_cpword.Text,
                    datereg=DateTime.Now
                };
                await tbl_Users.Insert(user);
                await DisplayAlert("Success", "You've successfuly registered!", "OK");
            }
        }
    } 
}