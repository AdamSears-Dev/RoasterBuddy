using System;
using System.ComponentModel.DataAnnotations;

namespace RoasterBuddy.Models
{
    public class Client
    {
        public Client()
        {
            Orders = new List<Order>();
        }

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Contact Information")]
        public string? ContactInformation { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
