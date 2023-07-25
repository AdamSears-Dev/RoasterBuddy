using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Source
{
    public class EditModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public EditModel(RoasterBuddy.Models.RoasterBuddyContext context)
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
            Source = source;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Source).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceExists(Source.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SourceExists(Guid id)
        {
            return (_context.Sources?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
