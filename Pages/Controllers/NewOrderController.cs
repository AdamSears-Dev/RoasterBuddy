using Microsoft.AspNetCore.Mvc;
using RoasterBuddy.Models;

namespace RoasterBuddy.Controllers
{
    public class OrderController : Controller
    {
        private readonly RoasterBuddyContext _context;

        public OrderController(RoasterBuddyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult NewOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the form data to an Order object
                var order = new Order
                {
                    Name = model.Client.Name,
                    SourceName = model.Source,
                    RoastLevel = model.RoastLevel,
                    Amount = model.Amount,
                    Price = model.Price
                };

                // Save the order to the database
                _context.Orders.Add(order);
                _context.SaveChanges();

                // Redirect to a success page or display a success message
                return RedirectToAction("Order");
            }

            // If the form data is not valid, return the create view with validation errors
            return View("Create", model);
        }
    }
}