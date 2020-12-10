using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    public class tbl_Categories
    {
        public string id { get; set; }
        public string cat_name { get; set; }
        public string cat_img { get; set; }

        public static async Task<List<tbl_Categories>>Read()
        {
            var categories = await App.MobileService.GetTable<tbl_Categories>().ToListAsync();
            return categories;
        }
    }
}
