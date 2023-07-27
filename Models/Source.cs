using System;
namespace RoasterBuddy.Models
{
    public class Source
    {
        public Guid ID { get; set; }
        public string? Farm { get; set; }
        public string? Location { get; set; }
        public decimal Cost { get; set; }
        
        // Navigation property for associated orders.
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

