using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_Costumer
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public static async Task<List<tbl_Costumer>> Read()
        {
            var use = await App.MobileService.GetTable<tbl_Costumer>().ToListAsync();
            return use;
        }

        public static async Task Insert(tbl_Costumer userss)
        {
            await App.MobileService.GetTable<tbl_Costumer>().InsertAsync(userss);
        }
    }

}
