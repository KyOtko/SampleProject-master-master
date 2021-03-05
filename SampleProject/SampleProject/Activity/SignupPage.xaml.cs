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
            try
            {
                if (entry_fname.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you First name!", "OK");
                    entry_fname.Focus();
                    return;
                }

                if (entry_lname.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Last name.", "OK");
                    entry_lname.Focus();
                    return;
                }
                if (entry_bname.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Store name!", "OK");
                    entry_bname.Focus();
                    return;
                }

                if (Address.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Complete Address.", "OK");
                    Address.Focus();
                    return;
                }

                if (contact_Num.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Contact Number.", "OK");
                    contact_Num.Focus();
                    return;
                }

                if (entry_email.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Email.", "OK");
                    entry_email.Focus();
                    return;
                }


                if (entry_pword.Text == null)
                {
                    await DisplayAlert("Field required", "Please enter you Password.", "OK");
                    entry_pword.Focus();
                    return;
                }

                if (entry_cpword.Text == null)
                {
                    await DisplayAlert("Field required", "Confirm Your Password.", "OK");
                    entry_cpword.Focus();
                    return;
                }
                if (entry_pword.Text == entry_cpword.Text)
                {
                    var user = new tbl_Users
                    {
                        first_name = entry_fname.Text,
                        last_name = entry_lname.Text,
                        company_name = entry_bname.Text,
                        address = Address.Text,
                        contact_number = contact_Num.Text,
                        email = entry_email.Text,
                        password = entry_cpword.Text,
                        datereg = DateTime.Now
                    };
                    await tbl_Users.Insert(user);
                    await DisplayAlert("Success", "You've successfully signed up! Please login to your account now!", "OK");
                    await Navigation.PopAsync(true);
                    return;
                }
                else
                {
                    await DisplayAlert("Confirm password", "Confirm your password!", "OK");
                    //confirmpassentry.Focus();
                }



            }          
            catch
            {
               //await tbl_Users.Insert(user);
                await DisplayAlert("Error", "User Information Alreary exist!", "OK" );
                return;
            }
        }
    } 
}