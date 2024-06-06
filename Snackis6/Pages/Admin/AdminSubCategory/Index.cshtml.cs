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
    public class IndexModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public IndexModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public IList<Subcategory> Subcategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Subcategory = await _context.subcategory
                .Include(s => s.Category).ToListAsync();
        }
    }
}
