using BlogApp.Models;
using System.Collections.Generic;

namespace BlogApp.ViewModels
{
    public class BlogDetailsCommentHistoryViewModel
    {
        public BlogDetailsCommentHistoryViewModel()
        {
            CommentEditHistory = new List<CommentEditHistory>();
            BlogPost = new BlogPost();
        }
        public List<CommentEditHistory> CommentEditHistory { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
