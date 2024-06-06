using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis6.Data;
using Snackis6.Models;

namespace Snackis6.Pages.Messages
{
    public class IndexModel : PageModel
    {
        private readonly Snackis6.Data.Snackis6Context _context;

        public IndexModel(Snackis6.Data.Snackis6Context context)
        {
            _context = context;
        }

        public IList<Message> Message { get;set; } = default!;
        public IList<Message> SentMessages { get; set; } = default!;


        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Message = await _context.Message
                      .Include(m => m.Recipient)
                      .Include(m => m.Sender)
                      .Where(m => m.RecipientId == userId)
                      .OrderByDescending(m => m.Timestamp)
                      .ToListAsync();

          SentMessages = await _context.Message
          .Include(m => m.Recipient)
          .Include(m => m.Sender)
          .Where(m => m.SenderId == userId)
          .OrderByDescending(m => m.Timestamp)
          .ToListAsync();
        }
    }
}
