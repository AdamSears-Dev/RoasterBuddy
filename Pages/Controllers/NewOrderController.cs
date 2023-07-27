using Microsoft.AspNetCore.Mvc;
using RoasterBuddy.Models;
using System;

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
                // Try to parse the roast level from the form data
                if (!Enum.TryParse<RoastLevels>(model.RoastLevel, true, out var roastLevelValue))
                {
                    // Handle the case where the string does not represent a valid RoastLevels value
                    // For now, we will add an error to the model state and then return the same view
                    ModelState.AddModelError("RoastLevel", "Invalid roast level provided. Please select 'Light', 'Medium' or 'Dark'.");
                    return View("Create", model);
                }

                // Map the form data to an Order object
                var order = new Order
                {
                    Name = model.Client.Name,
                    SourceId = model.Source,
                    RoastLevel = roastLevelValue,
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
