using BlogApp.Models;
using BlogApp.Models.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        // HomeController constructor with dependency injection
        // Initializes the _context and _userManager fields with the provided ApplicationDbContext and UserManager<ApplicationUser> instances
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; // Initializes the ApplicationDbContext field
            _userManager = userManager; // Initializes the UserManager<ApplicationUser> field
        }

        //Index action to list the blog 
        //page,sortby,searchString parameters to search and sort blogs
        public async Task<IActionResult> Index(int? page, string sortBy, string searchString)
        {
            int pageSize = 6; // Number of blog posts per page
            int pageNumber = page ?? 1; // If no page is specified, use page 1

            var blogPosts = _context.BlogPosts
                .Include(bp => bp.Author)
                .Include(bp => bp.Comments)
                .Include(bp => bp.Reactions)
                .OrderByDescending(bp => bp.CreatedAt); // Default sorting by creation date (newest first)

            // Apply sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                blogPosts = sortBy switch
                {
                    "title_asc" => blogPosts.OrderBy(bp => bp.Title),
                    "title_desc" => blogPosts.OrderByDescending(bp => bp.Title),
                    "popularity_asc" => blogPosts.OrderBy(bp => bp.PopularityScore),
                    "popularity_desc" => blogPosts.OrderByDescending(bp => bp.PopularityScore),
                    _ => blogPosts
                };
            }

            // Apply search
            if (!string.IsNullOrEmpty(searchString))
            {
                blogPosts = blogPosts.Where(bp => bp.Title.Contains(searchString) || bp.Body.Contains(searchString)).OrderByDescending(bp => bp.CreatedAt);
            }

            var paginated = await blogPosts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            // Sets ViewBag properties to be used for pagination and filtering
            ViewBag.PageNumber = pageNumber; // Current page number
            ViewBag.PageSize = pageSize; // Number of items per page
            ViewBag.TotalPages = Math.Ceiling((double)await blogPosts.CountAsync() / pageSize); // Total number of pages based on the count of blogPosts and pageSize
            ViewBag.SortBy = sortBy; // Sort criteria
            ViewBag.SearchString = searchString; // Search string


            return View(paginated);
        }

        // Retrieves a specific blog post with its related entities (author, comments, reactions, and comment reactions) and passes it to the view
        public IActionResult ReadBlog(int id)
        {
            var blog = _context.BlogPosts
                .Include(bp => bp.Author) // Include the Author navigation property
                .Include(bp => bp.Comments)
                    .ThenInclude(c => c.Author) // Include the Author navigation property for each comment
                .Include(bp => bp.Reactions)
                .FirstOrDefault(x => x.BlogPostId == id);

            // Include comment reactions for each comment
            foreach (var comment in blog.Comments)
            {
                comment.CommentReaction = _context.CommentReactions
                    .Include(cr => cr.Author)
                    .Where(cr => cr.CommentId == comment.CommentId)
                    .ToList();
            }

            return View(blog); // Returns the blog post to the view
        }


        #region Comment, Reactions and Notification Section

        // Adds a reaction to a blog post and creates a notification for the user
        [HttpPost]
        public IActionResult AddReaction(int id, bool isUpvote)
        {
            try
            {
                var reaction = new Reaction()
                {
                    BlogPostId = id, // Set the ID of the blog post for the reaction
                    AuthorId = GetUserId(User.Identity.Name), // Set the ID of the current user
                    IsUpvote = isUpvote, // Set whether the reaction is an upvote or not
                    CreatedAt = DateTime.Now // Set the creation date of the reaction
                };

                _context.Reactions.Add(reaction); // Add the reaction to the context
                _context.SaveChanges(); // Save changes to the database

                // Create a notification for the user
                CreateNotification(reaction.AuthorId, "Reaction", id, null);

                return Json("success"); // Return success message
            }
            catch
            {
                return Json(""); // Return empty response if there's an error
            }
        }


        // Adds a comment to a blog post and creates a notification for the user
        [HttpPost]
        public IActionResult AddComment(int id, string comment)
        {
            try
            {
                var commentEntity = new Comment()
                {
                    BlogPostId = id, // Set the ID of the blog post for the comment
                    AuthorId = GetUserId(User.Identity.Name), // Set the ID of the current user
                    Content = comment, // Set the content of the comment
                    CreatedAt = DateTime.Now // Set the creation date of the comment
                };

                _context.Comments.Add(commentEntity); // Add the comment to the context
                _context.SaveChanges(); // Save changes to the database

                // Create a notification for the user
                CreateNotification(commentEntity.AuthorId, "Comment", id, commentEntity.CommentId);

                return Json("success"); // Return success message
            }
            catch
            {
                return Json(""); // Return empty response if there's an error
            }
        }


        // Adds a reaction to a comment
        [HttpPost]
        public IActionResult AddCommentReaction(int id, bool isUpvote)
        {
            try
            {
                var reaction = new CommentReaction()
                {
                    CommentId = id, // Set the ID of the comment for the reaction
                    AuthorId = GetUserId(User.Identity.Name), // Set the ID of the current user
                    IsUpvote = isUpvote, // Set whether the reaction is an upvote or not
                    CreatedAt = DateTime.Now // Set the creation date of the reaction
                };

                _context.CommentReactions.Add(reaction); // Add the reaction to the context
                _context.SaveChanges(); // Save changes to the database

                return Json("success"); // Return success message
            }
            catch
            {
                return Json(""); // Return empty response if there's an error
            }
        }


        // Method to create a notification
        public void CreateNotification(string userId, string action, int blogPostId, int? commentId)
        {
            var notification = new Notification
            {
                UserId = userId,
                Action = action,
                BlogPostId = blogPostId,
                CommentId = commentId,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        // Method to get unread notifications for a user
        public List<Notification> GetUnreadNotifications(string userId)
        {
            return _context.Notifications.Where(n => n.UserId == userId && !n.IsRead).ToList();
        }

        // Method to mark a notification as read
        public void MarkNotificationAsRead(int notificationId)
        {
            var notification = _context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.Id == id);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetNotifications()
        {
            // Retrieve notifications for the logged-in user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notifications = _context.Notifications
                .Where(n => !n.IsRead)
                .ToList();
            var filteredNotifications = notifications
    .Where(n => _context.BlogPosts
                .Where(bp => bp.BlogPostId == n.BlogPostId)
                .Select(bp => bp.AuthorId)
                .FirstOrDefault() == userId)
    .ToList();
            // Map the notifications to a format suitable for JSON response
            var mappedNotifications = filteredNotifications.Select(n => new
            {
                NotificationId = n.Id,
                BlogId = n.BlogPostId,
                Type = n.Action, // Notification type, e.g., reaction or comment
                Message = n.Action == "Reaction" ? $"{_userManager.FindByIdAsync(n.UserId).Result.UserName} reacted on your post" : $"{_userManager.FindByIdAsync(n.UserId).Result.UserName} commented on your post"
            });

            return Json(mappedNotifications);
        }

        public string GetUserId(string name)
        {
            return _userManager.FindByNameAsync(name).Result.Id;
        }

        [HttpPost]
        public IActionResult UpdateComment(int commentId, string editedContent)
        {
            // Find the comment
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment == null)
            {
                return Json(new { success = false });
            }

            try
            {
                // Save the original comment content and timestamp before editing
                var originalContent = comment.Content;
                var originalTimestamp = comment.UpdatedAt;

                // Update the comment content
                comment.Content = editedContent;
                comment.UpdatedAt = DateTime.Now;

                // Save the edited comment
                _context.SaveChanges();

                // Save the edit history
                _context.CommentEditHistories.Add(new CommentEditHistory
                {
                    CommentId = comment.CommentId,
                    OriginalContent = originalContent,
                    EditedContent = editedContent,
                    OriginalTimestamp = originalTimestamp,
                    EditedTimestamp = DateTime.Now
                });
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);

            if (comment != null)
            {
                comment.IsDeleted = true;
                _context.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        #endregion


        #region Admin Dashboard
        // Retrieves the list of blog posts for the dashboard
        public IActionResult Dashboard()
        {
            // Retrieve blog posts with their related entities (author, comments, and reactions), ordered by creation date
            var blogList = _context.BlogPosts
                .Include(bp => bp.Author) // Include the Author navigation property
                .Include(bp => bp.Comments) // Include the Comments navigation property
                .Include(bp => bp.Reactions) // Include the Reactions navigation property
                .OrderByDescending(bp => bp.CreatedAt)
                .ToList();

            // Filter blog posts if user is in "Blogger" role
            if (User.IsInRole("Blogger"))
            {
                blogList = blogList.Where(x => x.Author.UserName == User.Identity.Name).ToList();
            }

            return View(blogList); // Pass the blog list to the view
        }
        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
