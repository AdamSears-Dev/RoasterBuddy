﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoasterBuddy.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateOnly DateOrdered { get; set; }
        public Guid? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string? RoastLevel { get; set; }
        public string? Source { get; set; }
    }
}

