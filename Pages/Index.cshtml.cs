using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RoasterBuddyContext _context;

        public IndexModel(RoasterBuddyContext context)
        {
            _context = context;
        }

        public IList<RoasterBuddy.Models.Client>? Clients { get; set; }
        public IList<RoasterBuddy.Models.Order>? Orders { get; set; }
        public IList<RoasterBuddy.Models.Source>? Sources { get; set; }
        public IList<RoasterBuddy.Models.Roast>? Roasts { get; set; }

        public async Task OnGetAsync()
        {
            Clients = await _context.Clients.ToListAsync();
            Orders = await _context.Orders.ToListAsync();
            Sources = await _context.Sources.ToListAsync();
            Roasts = await _context.Roasts.ToListAsync();
        }
    }
}
