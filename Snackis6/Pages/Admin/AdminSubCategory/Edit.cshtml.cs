using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages.Admin.AdminSubCategory
{
    public class EditModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public EditModel(Snackis6.Data.Snackis6Context context)
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
            Subcategory = subcategory;
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoryExists(Subcategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubcategoryExists(int id)
        {
            return _context.subcategory.Any(e => e.Id == id);
        }
    }
}
