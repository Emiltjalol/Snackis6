using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Areas.Identity.Data;
using Snackis6.Data;
using Snackis6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snackis6.Pages.Posts
{
    public class PostDetailsModel : PageModel
    {
        private readonly Snackis6Context _context;
        private readonly UserManager<Snackis6User> _userManager;

        public PostDetailsModel(Snackis6Context context, UserManager<Snackis6User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Post Post { get; set; }
        public IList<Comment> Comments { get; set; }
        public string CurrentUserId { get; set; }

        public async Task<IActionResult> OnGetAsync(int postId)
        {
            Post = await _context.Post
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.subCategory)
                .OrderByDescending(p => p.PostedTime)
                .FirstOrDefaultAsync(m => m.Id == postId);

            if (Post == null)
            {
                return NotFound();
            }

            Comments = await _context.Comment
                .Where(c => c.postId == postId)
                .Include(c => c.User)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            if (User.Identity.IsAuthenticated)
            {
                CurrentUserId = _userManager.GetUserId(User);
            }

            return Page();
        }
    }
}