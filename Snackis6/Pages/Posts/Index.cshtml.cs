using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Snackis6Context _context;

        public IndexModel(Snackis6Context context)
        {
            _context = context;
        }

        public IList<Post> Post { get; set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.subCategory)
                .OrderByDescending(p => p.PostedTime) // Order by PostedTime descending
                .ToListAsync();
        }
    }
}