using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Models.DBContext;
using BlogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BlogApp.ViewModels;

namespace BlogApplication.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogPostsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: BlogPosts
        public async Task<IActionResult> Index(int? page, string sortBy, string searchString)
        {
            int pageSize = 10; // Number of blog posts per page
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

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)await blogPosts.CountAsync() / pageSize);
            ViewBag.SortBy = sortBy;
            ViewBag.SearchString = searchString;

            return View(paginated);
        }

        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = new BlogDetailsCommentHistoryViewModel();
            model.BlogPost = await _context.BlogPosts
                .Include(bp => bp.Author)
                .Include(bp => bp.Comments)
                .Include(bp => bp.Reactions)
                .FirstOrDefaultAsync(bp => bp.BlogPostId == id);
            var commentIds = model.BlogPost.Comments.Select(c => c.CommentId).ToList();
            model.CommentEditHistory = await _context.CommentEditHistories
                .Where(x => commentIds.Contains(x.CommentId))
                .ToListAsync();
            return View(model);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "Blogger")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> Create([Bind("Title,Body")] BlogPost blogPost, IFormFile ImagePaths)
        {
            if (ModelState.IsValid)
            {
                if (ImagePaths != null)
                {
                    long fileSize = ImagePaths.Length;

                    if (fileSize > 3 * 1024 * 1024) // 3MB
                    {
                        ModelState.AddModelError("ImagePaths", "File size should not exceed 3MB.");
                        return View(blogPost);
                    }

                    // Save the file to the project's local path
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "BlogImages");

                    // Check if the directory exists, if not, create it
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    } 
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImagePaths.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImagePaths.CopyToAsync(stream);
                    }

                    // Save the file path to the database
                    blogPost.ImagePaths = "/BlogImages/" + uniqueFileName;
                }

                blogPost.AuthorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                blogPost.CreatedAt = DateTime.Now;
                _context.BlogPosts.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(blogPost);
        }


        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> Edit(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            // Check if the logged-in user is the author of the blog post
            if (blogPost.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Forbid();
            }

            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> Edit(int id, [Bind("BlogPostId,Title,Body,ImagePaths")] BlogPost blogPost)
        {
            if (id != blogPost.BlogPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBlogPost = await _context.BlogPosts.FindAsync(id);

                    // Check if the logged-in user is the author of the blog post
                    if (existingBlogPost.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
                    {
                        return View("AccessDenied");
                    }

                    // Save edit history
                    var editHistory = new BlogPostEditHistory
                    {
                        BlogPostId = existingBlogPost.BlogPostId,
                        OriginalTitle = existingBlogPost.Title,
                        OriginalBody = existingBlogPost.Body,
                        EditedTitle = blogPost.Title,
                        EditedBody = blogPost.Body,
                        OriginalTimestamp = existingBlogPost.UpdatedAt==null?DateTime.Now : (DateTime)existingBlogPost.UpdatedAt,
                        EditedTimestamp = DateTime.Now,
                        IsDeleted = false // Not deleted
                    };
                    _context.BlogPostEditHistories.Add(editHistory);

                    // Update the blog post
                    existingBlogPost.Title = blogPost.Title;
                    existingBlogPost.Body = blogPost.Body;
                    existingBlogPost.ImagePaths = blogPost.ImagePaths;
                    existingBlogPost.UpdatedAt = DateTime.Now;

                    _context.Entry(existingBlogPost).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }



        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> Delete(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            // Check if the logged-in user is the author of the blog post
            if (blogPost.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return View("AccessDenied");
            }

            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            // Check if the logged-in user is the author of the blog post
            if (blogPost.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Forbid();
            }
            blogPost.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.BlogPostId == id);
        }

        
        public async Task<IActionResult> History(int id)
        {
            var model = new BlogHistoryViewModel();
            model.BlogPost = await _context.BlogPosts
       .Include(x => x.Author)
       .FirstOrDefaultAsync(x => x.BlogPostId == id);
            model.BlogPostEditHistory = await _context.BlogPostEditHistories.Where(x=>x.BlogPostId==id).ToListAsync();
            return View(model);
        }
    }
}
