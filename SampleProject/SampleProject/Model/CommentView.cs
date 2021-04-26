using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    class CommentView
    {
        public string id { get; set; }

        public string user_id { get; set; }
        public string cus_id { get; set; }
        public string full_name { get; set; }
        public string comment { get; set; }

        public static async Task<List<CommentView>> Read()
        {
            var getComments = await App.MobileService.GetTable<CommentView>().ToListAsync();
            return getComments;
        }
        public static async Task Update(CommentView comment)
        {
             await App.MobileService.GetTable<CommentView>().UpdateAsync(comment);
        }
        public static async Task Insert(CommentView getcomment)
        {
            await App.MobileService.GetTable<CommentView>().InsertAsync(getcomment);
        }
    }
}
