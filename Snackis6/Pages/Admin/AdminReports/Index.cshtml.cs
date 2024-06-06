using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Models;

namespace Snackis6.Pages.Admin.AdminReports
{
    public class IndexModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public IndexModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public IList<Reported> Reported { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Reported = await _context.Reported
                .Include(r => r.Comment)
                .Include(r => r.ReportedUser)
                .Include(r => r.Reporter)
                .OrderByDescending(t => t.TimeStamp).ToListAsync();

        }
    }
}
