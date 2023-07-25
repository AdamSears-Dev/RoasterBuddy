using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Order
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
            var sources = _context.Sources.ToList();
            Console.WriteLine(sources.Count); // Debug line to check the number of sources


            ViewData["ClientName"] = new SelectList(_context.Clients, "ID", "Name");
            ViewData["SourceName"] = new SelectList(_context.Sources, "ID", "Farm");
            return Page();
        }

        [BindProperty]
        public RoasterBuddy.Models.Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            // Fetch the client based on the id provided in the order
            var client = await _context.Clients.FindAsync(Order.ClientId);
            var source = await _context.Sources.FindAsync(Order.SourceName);


            // Assign the client to the order
            Order.Client = client;

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
