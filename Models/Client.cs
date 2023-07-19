using System;
namespace RoasterBuddy.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ContactInformation { get; set; }
    }
}
