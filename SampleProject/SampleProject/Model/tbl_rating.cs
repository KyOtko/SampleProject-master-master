using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static SampleProject.App;

namespace SampleProject.Model
{
    class tbl_rating
    {
        public string Id { get; set; }
        public string user_id { get; set; }
        public string cus_id { get; set; }
        public double one_star { get; set; }
        public double two_star { get; set; }
        public double three_star { get; set; }
        public double four_star { get; set; }
        public double five_star { get; set; }
        public float rating { get; set; }

        public float tot_rate { get; set; }

        public static async Task Update(tbl_rating ratingU)
        {
            await App.MobileService.GetTable<tbl_rating>().UpdateAsync(ratingU);
        }

        public static async Task Insert(tbl_rating ratingD)
        {
            await App.MobileService.GetTable<tbl_rating>().InsertAsync(ratingD);
        }
        public static async Task<List<tbl_rating>> Read()
        {
            var bir = await App.MobileService.GetTable<tbl_rating>().ToListAsync();
            return bir;
        }
    }
}
