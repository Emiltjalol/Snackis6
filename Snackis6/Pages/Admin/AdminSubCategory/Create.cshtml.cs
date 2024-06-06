using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages.Admin.AdminSubCategory
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
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Subcategory Subcategory { get; set; } = default!;

   
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.subcategory.Add(Subcategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
