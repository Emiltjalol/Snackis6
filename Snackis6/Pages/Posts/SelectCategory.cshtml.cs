using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Posts
{
    public class SelectCategoryModel : PageModel
    {
        private readonly Snackis6Context _context;

        public SelectCategoryModel(Snackis6Context context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Category.ToListAsync();
        }
    }
}