using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class CommentReaction
    {
        [Key]
        public int ReactionId { get; set; }

        public bool IsUpvote { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}