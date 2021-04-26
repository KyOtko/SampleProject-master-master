using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_bir
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string birImg { get; set; }

        public static async Task Update(tbl_bir birupdate)
        {
            await App.MobileService.GetTable<tbl_bir>().UpdateAsync(birupdate);
        }

        public static async Task Insert(tbl_bir birdetails)
        {
            await App.MobileService.GetTable<tbl_bir>().InsertAsync(birdetails);
        }
        public static async Task<List<tbl_bir>> Read()
        {
            var bir = await App.MobileService.GetTable<tbl_bir>().ToListAsync();
            return bir;
        }
    }
}

