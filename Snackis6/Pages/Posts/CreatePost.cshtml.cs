using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;
using System.Security.Claims;

namespace Snackis6.Pages.Posts
{
    public class CreatePostModel : PageModel
    {
        private readonly Snackis6Context _context;

        public CreatePostModel(Snackis6Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = new Post();

        public string CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync(int categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            CategoryName = category.Name;
            Post.CategoryId = category.Id;

            ViewData["SubCategoryId"] = new SelectList(await _context.subcategory.Where(sc => sc.CategoryId == categoryId).ToListAsync(), "Id", "Name");

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var posterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(posterId))
                {
                    Post.UserId = posterId;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.PostedTime = DateTime.Now;
            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}