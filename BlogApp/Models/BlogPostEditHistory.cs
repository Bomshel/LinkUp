namespace BlogApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostEditHistory
    {
        [Key]
        public int BlogPostEditHistoryId { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public string OriginalTitle { get; set; }
        public string OriginalBody { get; set; }

        public string EditedTitle { get; set; }
        public string EditedBody { get; set; }

        public DateTime OriginalTimestamp { get; set; }
        public DateTime EditedTimestamp { get; set; }

        public bool IsDeleted { get; set; } 
    }

}
