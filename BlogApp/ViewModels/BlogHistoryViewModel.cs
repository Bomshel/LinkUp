using BlogApp.Models;
using System.Collections.Generic;

namespace BlogApp.ViewModels
{
    public class BlogHistoryViewModel
    {
        public BlogHistoryViewModel()
        {
            BlogPostEditHistory = new List<BlogPostEditHistory>();
            BlogPost = new BlogPost();
        }
    
        public List<BlogPostEditHistory> BlogPostEditHistory { get; set; }
        public BlogPost BlogPost { get; set; }  
    }
    public class BlogActivityByMonth
    {
        public string Month { get; set; }
        public int CommentCount { get; set; }
        public int ReactionCount { get; set; }
    }

}
