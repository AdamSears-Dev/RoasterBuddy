using Microsoft.EntityFrameworkCore;
using System;

namespace RoasterBuddy.Models
{
    public class RoasterBuddyContext : DbContext
    {
        public RoasterBuddyContext(DbContextOptions<RoasterBuddyContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid[] sourceIds = new Guid[10];
            for (int i = 0; i < 10; i++)
            {
                sourceIds[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<Source>().HasData(
                new Source { ID = sourceIds[0], Farm = "Fazenda Santa Ines, Minas Gerais", Location = "Brazil", Cost = 2.40m },
                new Source { ID = sourceIds[1], Farm = "Carmo Estate, Sul de Minas", Location = "Brazil", Cost = 2.75m },
                new Source { ID = sourceIds[2], Farm = "La Soledad, Acatenango", Location = "Guatemala", Cost = 4.67m },
                new Source { ID = sourceIds[3], Farm = "Finca El Injerto, Huehuetenango", Location = "Guatemala", Cost = 2.67m },
                new Source { ID = sourceIds[4], Farm = "Hacienda La Esmeralda, Boquete", Location = "Panama", Cost = 4.00m },
                new Source { ID = sourceIds[5], Farm = "Finca Deborah, Volcan", Location = "Panama", Cost = 3.00m },
                new Source { ID = sourceIds[6], Farm = "Hacienda El Roble, Santander", Location = "Colombia", Cost = 3.00m },
                new Source { ID = sourceIds[7], Farm = "Finca Los Nogales, Tolima", Location = "Colombia", Cost = 2.91m },
                new Source { ID = sourceIds[8], Farm = "Hunkute Cooperative, Sidamo", Location = "Ethiopia", Cost = 3.78m },
                new Source { ID = sourceIds[9], Farm = "Guji Highland Farm, Guji", Location = "Ethiopia", Cost = 4.29m }
            );

            Guid[] clientIds = new Guid[8];
            for (int i = 0; i < 8; i++)
            {
                clientIds[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<Client>().HasData(
                new Client { ID = clientIds[0], Name = "Bluegrass Beans", Address = "123 Main St, Louisville, KY", ContactInformation = "bluegrassbeans@example.com" },
                new Client { ID = clientIds[1], Name = "River City Roasts", Address = "456 River Rd, Louisville, KY", ContactInformation = "rivercityroasts@example.com" },
                new Client { ID = clientIds[2], Name = "Derby Day Coffee", Address = "789 Derby Ln, Louisville, KY", ContactInformation = "derbydaycoffee@example.com" },
                new Client { ID = clientIds[3], Name = "Bardstown Brews", Address = "321 Bardstown Rd, Louisville, KY", ContactInformation = "bardstownbrews@example.com" },
                new Client { ID = clientIds[4], Name = "Southern Comfort Cafe", Address = "654 Southern Pkwy, Louisville, KY", ContactInformation = "southerncomfortcafe@example.com" },
                new Client { ID = clientIds[5], Name = "Cherokee Park Perks", Address = "987 Cherokee Rd, Louisville, KY", ContactInformation = "cherokeeparkperks@example.com" },
                new Client { ID = clientIds[6], Name = "Churchill Grinds", Address = "135 Churchill Dr, Louisville, KY", ContactInformation = "churchillgrinds@example.com" },
                new Client { ID = clientIds[7], Name = "NuLu Java", Address = "246 East Market St, Louisville, KY", ContactInformation = "nulujava@example.com" }
            );

            // for the sake of example I'm linking each order with first client and first source. Please modify according to your needs
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "Bluegrass Beans",
                    SourceId = sourceIds[0],
                    ClientId = clientIds[0],
                    RoastLevel = RoastLevels.Light,
                    Amount = 10,
                    Price = 120.00m,
                    DateOrdered = DateTime.Now
                },
                new Order
                {
                    ID = Guid.NewGuid(),
                    Name = "River City Roasts",
                    SourceId = sourceIds[1],
                    ClientId = clientIds[1],
                    RoastLevel = RoastLevels.Medium,
                    Amount = 8,
                    Price = 110.00m,
                    DateOrdered = DateTime.Now
                }
                //...
                // Add more orders here
                //...
            );
        }
    }
}
