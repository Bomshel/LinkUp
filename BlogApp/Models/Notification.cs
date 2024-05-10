using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; } // Comment, Reaction, etc.
        public int BlogPostId { get; set; }
        public int? CommentId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
