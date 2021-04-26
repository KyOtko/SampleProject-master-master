using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_userCat
    {
        public string Id { get; set; }
        public string user_id { get; set; }
        public string cover_img { get; set; }
        public string company_name { get; set; }
        public string cat_name { get; set; }

        public static async Task Insert(tbl_userCat usrdetails)
        {
            await App.MobileService.GetTable<tbl_userCat>().InsertAsync(usrdetails);
        }
        public static async Task<List<tbl_userCat>> Read()
        {
            var usrcat = await App.MobileService.GetTable<tbl_userCat>().ToListAsync();
            return usrcat;
        }
    }
}
