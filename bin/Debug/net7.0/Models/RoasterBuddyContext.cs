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
            // Seed data for the Orders table
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Bluegrass Beans",
                    SourceName = "Fazenda Santa Ines, Minas Gerais, Brazil",
                    RoastLevel = "Light",
                    Amount = 10,
                    Price = 120.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "River City Roasts",
                    SourceName = "Carmo Estate, Sul de Minas, Brazil",
                    RoastLevel = "Medium",
                    Amount = 8,
                    Price = 110.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Derby Day Coffee",
                    SourceName = "La Soledad, Acatenango, Guatemala",
                    RoastLevel = "Dark",
                    Amount = 6,
                    Price = 140.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Bardstown Brews",
                    SourceName = "Finca El Injerto, Huehuetenango, Guatemala",
                    RoastLevel = "Medium",
                    Amount = 12,
                    Price = 160.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Southern Comfort Cafe",
                    SourceName = "Hacienda La Esmeralda, Boquete, Panama",
                    RoastLevel = "Dark",
                    Amount = 9,
                    Price = 180.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Cherokee Park Perks",
                    SourceName = "Finca Deborah, Volcan, Panama",
                    RoastLevel = "Medium",
                    Amount = 10,
                    Price = 150.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Churchill Grinds",
                    SourceName = "Hacienda El Roble, Santander, Colombia",
                    RoastLevel = "Dark",
                    Amount = 8,
                    Price = 120.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "NuLu Java",
                    SourceName = "Finca Los Nogales, Tolima, Colombia",
                    RoastLevel = "Medium",
                    Amount = 11,
                    Price = 160.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Bluegrass Beans",
                    SourceName = "Hunkute Cooperative, Sidamo, Ethiopia",
                    RoastLevel = "Light",
                    Amount = 9,
                    Price = 170.00m
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "River City Roasts",
                    SourceName = "Guji Highland Farm, Guji, Ethiopia",
                    RoastLevel = "Dark",
                    Amount = 7,
                    Price = 150.00m
                }
            );

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
                {
                    modelBuilder.Entity<Source>().HasData(
                new Source { ID = Guid.NewGuid(), Farm = "Fazenda Santa Ines, Minas Gerais", Location = "Brazil", Cost = 2.40m },
                new Source { ID = Guid.NewGuid(), Farm = "Carmo Estate, Sul de Minas", Location = "Brazil", Cost = 2.75m },
                new Source { ID = Guid.NewGuid(), Farm = "La Soledad, Acatenango", Location = "Guatemala", Cost = 4.67m },
                new Source { ID = Guid.NewGuid(), Farm = "Finca El Injerto, Huehuetenango", Location = "Guatemala", Cost = 2.67m },
                new Source { ID = Guid.NewGuid(), Farm = "Hacienda La Esmeralda, Boquete", Location = "Panama", Cost = 4.00m },
                new Source { ID = Guid.NewGuid(), Farm = "Finca Deborah, Volcan", Location = "Panama", Cost = 3.00m },
                new Source { ID = Guid.NewGuid(), Farm = "Hacienda El Roble, Santander", Location = "Colombia", Cost = 3.00m },
                new Source { ID = Guid.NewGuid(), Farm = "Finca Los Nogales, Tolima", Location = "Colombia", Cost = 2.91m },
                new Source { ID = Guid.NewGuid(), Farm = "Hunkute Cooperative, Sidamo", Location = "Ethiopia", Cost = 3.78m },
                new Source { ID = Guid.NewGuid(), Farm = "Guji Highland Farm, Guji", Location = "Ethiopia", Cost = 4.29m }
            );



            }

        }
    }

}