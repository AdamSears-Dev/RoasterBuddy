using System.ComponentModel.DataAnnotations;

namespace RoasterBuddy.Models
{
    public class OrderViewModel
    {
        [Required]
        public Client Client { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string RoastLevel { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}