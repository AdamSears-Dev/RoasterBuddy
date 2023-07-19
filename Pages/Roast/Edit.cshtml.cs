using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Roast
{
    public class EditModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public EditModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoasterBuddy.Models.Roast Roast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Roasts == null)
            {
                return NotFound();
            }

            var roast =  await _context.Roasts.FirstOrDefaultAsync(m => m.ID == id);
            if (roast == null)
            {
                return NotFound();
            }
            Roast = roast;
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

            _context.Attach(Roast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoastExists(Roast.ID))
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

        private bool RoastExists(int id)
        {
          return (_context.Roasts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
