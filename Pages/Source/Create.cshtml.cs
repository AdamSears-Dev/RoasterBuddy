using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Source
{
    public class CreateModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public CreateModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoasterBuddy.Models.Source Source { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sources == null || Source == null)
            {
                return Page();
            }

            _context.Sources.Add(Source);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
