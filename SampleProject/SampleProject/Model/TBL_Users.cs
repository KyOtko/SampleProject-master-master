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
        public string email { get; set; }
        public string company_name { get; set; }
        public string password { get; set; }
        public DateTime datereg { get; set; }
        public string cover_img { get; set; }
        public string listing { get; set; }

        public static async Task<List<tbl_Users>> Read()
        {
            var Users = await App.MobileService.GetTable<tbl_Users>().ToListAsync();
            return Users;
        }

        public static async Task Insert(tbl_Users userdetails)
        {
            await App.MobileService.GetTable<tbl_Users>().InsertAsync(userdetails);
        }
    }
}
