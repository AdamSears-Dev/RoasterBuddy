using System;
namespace RoasterBuddy.Models
{
    public class Source
    {
        public Guid ID { get; set; }
        public string? Farm { get; set; }
        public string? Location { get; set; }
        public decimal Cost { get; set; }
    }
}

