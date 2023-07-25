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
    public class DeleteModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public DeleteModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Sources == null)
            {
                return NotFound();
            }
            var source = await _context.Sources.FindAsync(id);

            if (source != null)
            {
                Source = source;
                _context.Sources.Remove(Source);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
