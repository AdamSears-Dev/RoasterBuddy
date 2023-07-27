using System.ComponentModel.DataAnnotations;

namespace RoasterBuddy.Models
{
    public class OrderViewModel
    {
        [Required]
        public Client? Client { get; set; }

        [Required]
        public Guid? Source { get; set; } // Changed from string to Guid?

        [Required]
        public string? RoastLevel { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Date ordered is required.")]
        public DateTime DateOrdered { get; set; }
    }

}