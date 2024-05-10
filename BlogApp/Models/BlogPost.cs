using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; } // Explicitly define the primary key property

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        public string ImagePaths { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PopularityScore { get; set; }
        public bool IsDeleted { get; set; }
    }
}
