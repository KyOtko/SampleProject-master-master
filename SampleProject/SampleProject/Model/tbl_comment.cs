using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_comment
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string cus_id { get; set; }

        public string comment { get; set; }
        public double ratings { get; set; }
        public string served { get; set; }
        public static async Task<List<tbl_comment>> Read()
        {
            var Users = await App.MobileService.GetTable<tbl_comment>().ToListAsync();
            return Users;
        }

        public static async Task Insert(tbl_comment userdetails)
        {
            await App.MobileService.GetTable<tbl_comment>().InsertAsync(userdetails);
        }
    }
}
