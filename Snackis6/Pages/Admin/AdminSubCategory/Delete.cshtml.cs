using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages.Admin.AdminSubCategory
{
    public class DeleteModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public DeleteModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Subcategory Subcategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.subcategory.FirstOrDefaultAsync(m => m.Id == id);

            if (subcategory == null)
            {
                return NotFound();
            }
            else
            {
                Subcategory = subcategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.subcategory.FindAsync(id);
            if (subcategory != null)
            {
                Subcategory = subcategory;
                _context.subcategory.Remove(Subcategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
