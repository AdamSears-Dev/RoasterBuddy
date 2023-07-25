using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoasterBuddy.Models;

namespace RoasterBuddy.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

        public EditModel(RoasterBuddy.Models.RoasterBuddyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoasterBuddy.Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;

            // Check if _context.Clients contains any elements
            if (_context.Clients != null && _context.Clients.Any())
            {
                // Exclude null clients or clients without names
                var clientsList = _context.Clients.Where(c => c != null && c.Name != null);

                // Check if clientsList contains any elements
                if (clientsList.Any())
                {
                    ViewData["ClientName"] = new SelectList(clientsList, "ID", "Name");
                }
                else
                {
                    ViewData["ClientName"] = new SelectList(new List<RoasterBuddy.Models.Client>(), "ID", "Name");
                }
            }
            else
            {
                ViewData["ClientName"] = new SelectList(new List<RoasterBuddy.Models.Client>(), "ID", "Name");
            }

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

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
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

        private bool OrderExists(Guid id)
        {
            return (_context.Orders?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

//namespace RoasterBuddy.Pages.Order
//{
//    public class EditModel : PageModel
//    {
//        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

//        public EditModel(RoasterBuddy.Models.RoasterBuddyContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public RoasterBuddy.Models.Order Order { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(Guid? id)
//        {
//            if (id == null || _context.Orders == null)
//            {
//                return NotFound();
//            }


//            var order = await _context.Orders.FirstOrDefaultAsync(m => m.ID == id);
//            if (order == null)
//            {
//                return NotFound();
//            }
//            Order = order;
//            ViewData["ClientName"] = new SelectList(_context.Clients, "ID", "ClientName"); // updated this line
//            return Page();
//        }

//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(Order).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!OrderExists(Order.ID))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool OrderExists(Guid id)
//        {
//            return (_context.Orders?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}


////namespace RoasterBuddy.Pages.Order
////{
////    public class EditModel : PageModel
////    {
////        private readonly RoasterBuddy.Models.RoasterBuddyContext _context;

////        public EditModel(RoasterBuddy.Models.RoasterBuddyContext context)
////        {
////            _context = context;
////        }

////        [BindProperty]
////        public RoasterBuddy.Models.Order Order { get; set; } = default!;

////        public async Task<IActionResult> OnGetAsync(Guid? id)
////        {
////            if (id == null || _context.Orders == null)
////            {
////                return NotFound();
////            }

////            var order =  await _context.Orders.FirstOrDefaultAsync(m => m.ID == id);
////            if (order == null)
////            {
////                return NotFound();
////            }
////            Order = order;
////           ViewData["ClientName"] = new SelectList(_context.Clients, "ID", "ID");
////            return Page();
////        }

////        // To protect from overposting attacks, enable the specific properties you want to bind to.
////        // For more details, see https://aka.ms/RazorPagesCRUD.
////        public async Task<IActionResult> OnPostAsync()
////        {
////            if (!ModelState.IsValid)
////            {
////                return Page();
////            }

////            _context.Attach(Order).State = EntityState.Modified;

////            try
////            {
////                await _context.SaveChangesAsync();
////            }
////            catch (DbUpdateConcurrencyException)
////            {
////                if (!OrderExists(Order.ID))
////                {
////                    return NotFound();
////                }
////                else
////                {
////                    throw;
////                }
////            }

////            return RedirectToPage("./Index");
////        }

////        private bool OrderExists(Guid id)
////        {
////          return (_context.Orders?.Any(e => e.ID == id)).GetValueOrDefault();
////        }
////    }
////}
