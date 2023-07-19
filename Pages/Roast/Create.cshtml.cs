using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Roast
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
        public RoasterBuddy.Models.Roast Roast { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Roasts == null || Roast == null)
            {
                return Page();
            }

            _context.Roasts.Add(Roast);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
