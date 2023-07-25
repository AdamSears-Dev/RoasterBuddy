using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Source
{
    public class DetailsModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public DetailsModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

      public RoasterBuddy.Models.Source Source { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Sources == null)
            {
                return NotFound();
            }

            var source = await _context.Sources.FirstOrDefaultAsync(m => m.ID == id);
            if (source == null)
            {
                return NotFound();
            }
            else 
            {
                Source = source;
            }
            return Page();
        }
    }
}
