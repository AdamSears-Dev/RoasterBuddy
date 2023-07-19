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
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    RoastLevel = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
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
                    { new Guid("2d1a63cf-31ae-453a-b3a8-ff632aa12d55"), "246 East Market St, Louisville, KY", "nulujava@example.com", "NuLu Java" },
                    { new Guid("41913251-fd7e-4db1-8b18-0202f6105ce9"), "456 River Rd, Louisville, KY", "rivercityroasts@example.com", "River City Roasts" },
                    { new Guid("6bd92ed2-8924-4c0e-b79e-7aaad8830af2"), "789 Derby Ln, Louisville, KY", "derbydaycoffee@example.com", "Derby Day Coffee" },
                    { new Guid("aac7834f-30ec-4675-b7e4-c653365bcd12"), "654 Southern Pkwy, Louisville, KY", "southerncomfortcafe@example.com", "Southern Comfort Cafe" },
                    { new Guid("b67f5f89-9d69-49b5-8415-39e4d0819825"), "123 Main St, Louisville, KY", "bluegrassbeans@example.com", "Bluegrass Beans" },
                    { new Guid("b8e64727-a71a-4d7f-97dd-5ffb8a041244"), "135 Churchill Dr, Louisville, KY", "churchillgrinds@example.com", "Churchill Grinds" },
                    { new Guid("faf98f72-d185-4f91-b7f5-39fcd186df33"), "321 Bardstown Rd, Louisville, KY", "bardstownbrews@example.com", "Bardstown Brews" },
                    { new Guid("fe65b1ce-4c01-4282-887d-c59a61950c76"), "987 Cherokee Rd, Louisville, KY", "cherokeeparkperks@example.com", "Cherokee Park Perks" }
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
