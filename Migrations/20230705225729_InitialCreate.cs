using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoasterBuddy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInformation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roasts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RoastLevel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roasts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Farm = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOrdered = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "ContactInformation", "Name" },
                values: new object[,]
                {
                    { new Guid("0d5c991f-8aa3-4bb5-a373-347f4ee2c14a"), "789 Derby Ln, Louisville, KY", "derbydaycoffee@example.com", "Derby Day Coffee" },
                    { new Guid("2a3194d9-91b2-445e-a104-539cfdc05a90"), "246 East Market St, Louisville, KY", "nulujava@example.com", "NuLu Java" },
                    { new Guid("353c78e6-c1f6-40ba-bc4e-405ca76ecb5b"), "654 Southern Pkwy, Louisville, KY", "southerncomfortcafe@example.com", "Southern Comfort Cafe" },
                    { new Guid("36f8ac8b-205d-46bf-8949-260527b1af45"), "135 Churchill Dr, Louisville, KY", "churchillgrinds@example.com", "Churchill Grinds" },
                    { new Guid("4c2d9120-cf7a-44cc-895b-90a89159a6e5"), "321 Bardstown Rd, Louisville, KY", "bardstownbrews@example.com", "Bardstown Brews" },
                    { new Guid("50d1b4ea-fca9-4c61-9863-357d959d6f18"), "123 Main St, Louisville, KY", "bluegrassbeans@example.com", "Bluegrass Beans" },
                    { new Guid("9faded71-46eb-477e-9c20-42e38f7e1a6a"), "456 River Rd, Louisville, KY", "rivercityroasts@example.com", "River City Roasts" },
                    { new Guid("a7f70ea1-1e9b-40fc-a05a-58c97db1e1ef"), "987 Cherokee Rd, Louisville, KY", "cherokeeparkperks@example.com", "Cherokee Park Perks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roasts");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
