using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoasterBuddy.Models
{
    public enum RoastLevels
    {
        Light,
        Medium,
        Dark
    }

    public class Order
    {
        // old //

        /*public Guid ID { get; set; }
        public DateOnly DateOrdered { get; set; }
        public Guid? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string? RoastLevel { get; set; }
        public string? Source { get; set; }*/

        public Guid ID { get; set; }
        public DateTime DateOrdered { get; set; }
        public Guid? ClientId { get; set; }
        public Client? Client { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        [EnumDataType(typeof(RoastLevels))]
        public RoastLevels RoastLevel { get; set; }
        public Guid? SourceId { get; set; }
       // not needed public string? SourceName { get; set; }

        // The [ForeignKey] attribute specifies which property is the foreign key in a relationship.
        [ForeignKey("SourceId")]
        public Source? Source { get; set; }
    }
}



