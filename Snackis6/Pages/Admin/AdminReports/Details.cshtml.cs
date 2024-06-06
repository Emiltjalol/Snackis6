using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Admin.AdminReports
{
    public class DetailsModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public DetailsModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public Reported Reported { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reported = await _context.Reported.FirstOrDefaultAsync(m => m.Id == id);
            if (reported == null)
            {
                return NotFound();
            }
            else
            {
                Reported = reported;
            }
            return Page();
        }
    }
}
