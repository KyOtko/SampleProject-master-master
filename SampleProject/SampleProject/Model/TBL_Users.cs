using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_Users
    {
        public string Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string contact_number { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime datereg { get; set; }

        public static async Task Insert(tbl_Users userdetails)
        {
            await App.MobileService.GetTable<tbl_Users>().InsertAsync(userdetails);
        }
    }
}
