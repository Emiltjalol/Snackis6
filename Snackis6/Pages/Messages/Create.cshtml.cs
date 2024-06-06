using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages
{
    public class CreateModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public CreateModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
           ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "DisplayName");
            var senderId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the logged-in user's ID
            if (!string.IsNullOrEmpty(senderId))
            {
                Message = new Message { SenderId = senderId }; // Initialize Message and set SenderId
            }
            return Page();
        }

        [BindProperty]
        public Message Message { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Message.Timestamp = DateTime.Now;
            Message.IsRead = false;

            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
