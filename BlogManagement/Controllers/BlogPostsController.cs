using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BlogManagement.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly BlogContext _context;

        public BlogPostsController(BlogContext context)
        {
            _context = context;
        }

        // GET: BlogPosts
        public async Task<IActionResult> Index()
        {

           
            var blogContext = _context.BlogPosts.Include(b => b.Category);
            return View(await blogContext.ToListAsync());
        }

        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BlogPosts == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Create
       // [Authorize]
        public IActionResult Create()
        {
           ViewBag.CategoryList = GetAllCategory();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
          
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,ContentBlogPost,CategoryId")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", blogPost.CategoryId);
            return View(blogPost);
        }



        
       // [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BlogPosts == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       // [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BlogPosts == null)
            {
                return Problem("Entity set 'BlogContext.BlogPosts'  is null.");
            }
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
          return (_context.BlogPosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public IDictionary<string, string> GetAllCategory()
        {

            IDictionary<string, string> CategoryList = new Dictionary<string, string>();


            foreach (var Row in _context.Categories.ToList())
            {
                CategoryList.Add(Row.Id.ToString(), Row.CategoryName.ToString());
            }
            return CategoryList;
        }

       
    }
}
