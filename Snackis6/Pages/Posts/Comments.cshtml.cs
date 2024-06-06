using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snackis6.Data;
using Snackis6.Models;
using System.Security.Claims;

namespace Snackis6.Pages.Comments
{
    public class CreateModel : PageModel
    {
        private readonly Snackis6Context _context;

        public CreateModel(Snackis6Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        public IActionResult OnGet(int postId, int categoryId, int subCategoryId)
        {
            ViewData["categoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["subCategoryId"] = new SelectList(_context.subcategory, "Id", "Name");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                Comment = new Comment
                {
                    userId = userId,
                    postId = postId,
                    categoryId = categoryId,
                    subCategoryId = subCategoryId
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Comment.CreatedAt = DateTime.Now;

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Posts/PostDetails", new { postId = Comment.postId });
        }
    }
}
