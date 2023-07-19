using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Roast
{
    public class DetailsModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public DetailsModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

      public RoasterBuddy.Models.Roast Roast { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Roasts == null)
            {
                return NotFound();
            }

            var roast = await _context.Roasts.FirstOrDefaultAsync(m => m.ID == id);
            if (roast == null)
            {
                return NotFound();
            }
            else 
            {
                Roast = roast;
            }
            return Page();
        }
    }
}
