using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages
{
    public class DetailsModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public DetailsModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public Message Message { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message.FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            else
            {
                Message = message;
            }
            return Page();
        }
    }
}
