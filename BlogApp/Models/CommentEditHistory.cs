using System.ComponentModel.DataAnnotations;
using System;

namespace BlogApp.Models
{
    public class CommentEditHistory
    {
        [Key]
        public int CommentEditHistoryId { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public string OriginalContent { get; set; }
        public string EditedContent { get; set; }

        public DateTime OriginalTimestamp { get; set; }
        public DateTime EditedTimestamp { get; set; }
    }
}
