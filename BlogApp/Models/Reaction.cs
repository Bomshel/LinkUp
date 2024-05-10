using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Reaction
    {
        [Key]
        public int ReactionId { get; set; }

        public bool IsUpvote { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}