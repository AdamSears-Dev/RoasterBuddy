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
                    ContactInformation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Farm = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
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
                    DateOrdered = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    RoastLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orders_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "ContactInformation", "Name" },
                values: new object[,]
                {
                    { new Guid("1a4be23b-e81d-499a-ae49-129b61b2d12c"), "654 Southern Pkwy, Louisville, KY", "southerncomfortcafe@example.com", "Southern Comfort Cafe" },
                    { new Guid("4aff52d3-7077-4ca4-b070-8f3f45ee98b5"), "135 Churchill Dr, Louisville, KY", "churchillgrinds@example.com", "Churchill Grinds" },
                    { new Guid("4e21b65e-202b-4e56-9184-86c1c8f61410"), "789 Derby Ln, Louisville, KY", "derbydaycoffee@example.com", "Derby Day Coffee" },
                    { new Guid("a3480537-8058-4499-a0aa-7717b261f826"), "321 Bardstown Rd, Louisville, KY", "bardstownbrews@example.com", "Bardstown Brews" },
                    { new Guid("aad6251c-be37-48aa-9d22-67b2ad183c2b"), "246 East Market St, Louisville, KY", "nulujava@example.com", "NuLu Java" },
                    { new Guid("acdda976-63ad-47fa-b7d6-d89ea9ecbfe5"), "456 River Rd, Louisville, KY", "rivercityroasts@example.com", "River City Roasts" },
                    { new Guid("ed8ba7b1-58c5-48ec-8843-e02b226347ad"), "987 Cherokee Rd, Louisville, KY", "cherokeeparkperks@example.com", "Cherokee Park Perks" },
                    { new Guid("f8c6521e-8aab-4927-86ba-fdbc0bb0d0eb"), "123 Main St, Louisville, KY", "bluegrassbeans@example.com", "Bluegrass Beans" }
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "ID", "Cost", "Farm", "Location" },
                values: new object[,]
                {
                    { new Guid("07b4d790-a98e-480a-85c2-0f03882c6be9"), 4.67m, "La Soledad, Acatenango", "Guatemala" },
                    { new Guid("1a4d58e2-ba0b-4153-af81-fd0b6049e348"), 2.40m, "Fazenda Santa Ines, Minas Gerais", "Brazil" },
                    { new Guid("282b9b7e-21f7-43c7-a275-10ddb989970f"), 4.00m, "Hacienda La Esmeralda, Boquete", "Panama" },
                    { new Guid("395c5405-206b-441e-9c04-3dc67f285481"), 2.91m, "Finca Los Nogales, Tolima", "Colombia" },
                    { new Guid("611ce66e-f50c-48d8-9ad6-e6233f76d1b2"), 2.67m, "Finca El Injerto, Huehuetenango", "Guatemala" },
                    { new Guid("9d9b6bd1-8724-4599-997b-29851e27370e"), 3.00m, "Hacienda El Roble, Santander", "Colombia" },
                    { new Guid("bebaae8a-9742-415a-9619-0d3f3d1e0710"), 3.00m, "Finca Deborah, Volcan", "Panama" },
                    { new Guid("d1a363a7-f81f-4bec-ad3b-6dbd565904ce"), 4.29m, "Guji Highland Farm, Guji", "Ethiopia" },
                    { new Guid("e025b756-c544-4101-99e9-4d1e396c4674"), 3.78m, "Hunkute Cooperative, Sidamo", "Ethiopia" },
                    { new Guid("ff85d5a3-945b-4a97-9d61-d808f3893e5f"), 2.75m, "Carmo Estate, Sul de Minas", "Brazil" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Amount", "ClientId", "DateOrdered", "Name", "Price", "RoastLevel", "SourceId" },
                values: new object[,]
                {
                    { new Guid("98f7cb52-0b0f-4b5e-8594-a20adb9a6da9"), 10, new Guid("f8c6521e-8aab-4927-86ba-fdbc0bb0d0eb"), new DateTime(2023, 7, 26, 21, 50, 9, 47, DateTimeKind.Local).AddTicks(1351), "Bluegrass Beans", 120.00m, 0, new Guid("1a4d58e2-ba0b-4153-af81-fd0b6049e348") },
                    { new Guid("fd996062-bd49-4bd8-9bca-297bbcc21cff"), 8, new Guid("acdda976-63ad-47fa-b7d6-d89ea9ecbfe5"), new DateTime(2023, 7, 26, 21, 50, 9, 47, DateTimeKind.Local).AddTicks(1427), "River City Roasts", 110.00m, 1, new Guid("ff85d5a3-945b-4a97-9d61-d808f3893e5f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SourceId",
                table: "Orders",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
