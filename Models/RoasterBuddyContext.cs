using System;
using Microsoft.EntityFrameworkCore;

namespace RoasterBuddy.Models
{
    public class RoasterBuddyContext : DbContext
    {
        public RoasterBuddyContext(DbContextOptions<RoasterBuddyContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Roast> Roasts { get; set; }
        public DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
         new Client { ID = Guid.NewGuid(), Name = "Bluegrass Beans", Address = "123 Main St, Louisville, KY", ContactInformation = "bluegrassbeans@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "River City Roasts", Address = "456 River Rd, Louisville, KY", ContactInformation = "rivercityroasts@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "Derby Day Coffee", Address = "789 Derby Ln, Louisville, KY", ContactInformation = "derbydaycoffee@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "Bardstown Brews", Address = "321 Bardstown Rd, Louisville, KY", ContactInformation = "bardstownbrews@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "Southern Comfort Cafe", Address = "654 Southern Pkwy, Louisville, KY", ContactInformation = "southerncomfortcafe@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "Cherokee Park Perks", Address = "987 Cherokee Rd, Louisville, KY", ContactInformation = "cherokeeparkperks@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "Churchill Grinds", Address = "135 Churchill Dr, Louisville, KY", ContactInformation = "churchillgrinds@example.com" },
         new Client { ID = Guid.NewGuid(), Name = "NuLu Java", Address = "246 East Market St, Louisville, KY", ContactInformation = "nulujava@example.com" }
             );

        }

    }
}