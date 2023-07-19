using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public IndexModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        public IList<RoasterBuddy.Models.Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clients != null)
            {
                Client = await _context.Clients.ToListAsync();
            }
        }
    }
}
