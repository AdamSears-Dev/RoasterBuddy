using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public IndexModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        public IList<RoasterBuddy.Models.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Source)  
            .ToListAsync();
            }
        }

    }
}

    


