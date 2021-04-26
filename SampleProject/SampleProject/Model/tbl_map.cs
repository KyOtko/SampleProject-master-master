using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class tbl_map
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        public static async Task<List<tbl_map>> Read()
        {
            var mapp = await App.MobileService.GetTable<tbl_map>().ToListAsync();
            return mapp;
        }
    }
}
