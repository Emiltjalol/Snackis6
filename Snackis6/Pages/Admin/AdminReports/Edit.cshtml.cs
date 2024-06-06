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

namespace Snackis6.Pages.Admin.AdminReports
{
    public class EditModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public EditModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Reported Reported { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reported =  await _context.Reported.FirstOrDefaultAsync(m => m.Id == id);
            if (reported == null)
            {
                return NotFound();
            }
            Reported = reported;
           ViewData["CommentId"] = new SelectList(_context.Comment, "Id", "Id");
           ViewData["ReportedUserId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["ReporterId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reported).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportedExists(Reported.Id))
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

        private bool ReportedExists(int id)
        {
            return _context.Reported.Any(e => e.Id == id);
        }
    }
}
