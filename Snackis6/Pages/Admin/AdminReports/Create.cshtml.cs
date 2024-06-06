using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Snackis6.Areas.Identity.Data;
using Snackis6.Data;
using Snackis6.Models;



namespace Snackis6.Pages.Admin.AdminReports
{
    public class CreateModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;
        private readonly UserManager<Snackis6User> _userManager;

        public CreateModel(Snackis6.Data.Snackis6Context context, UserManager<Snackis6User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Reported Reported { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? commentId)
        {
            if (commentId == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == commentId);
            if (comment == null)
            {
                return NotFound();
            }

            // Set ReportedUserId to the comment's user ID
            Reported = new Reported
            {
                CommentId = comment.Id,
                ReportedUserId = comment.User.Id,
                ReporterId = "123",
                TimeStamp = DateTime.Now
            };

            ViewData["CommentContent"] = comment.CommentContent;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            // Ensure ReporterId is correctly set
            Reported.ReporterId = user.Id;

        

            if (!ModelState.IsValid)
            {
                var comment = await _context.Comment.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == Reported.CommentId);
                ViewData["CommentContent"] = comment?.CommentContent;
                return Page();
            }

            _context.Reported.Add(Reported);
            await _context.SaveChangesAsync();


            

            return RedirectToPage("/admin/adminreports/reported");
            //return RedirectToPage("/comments/reported");
        }
    }
}