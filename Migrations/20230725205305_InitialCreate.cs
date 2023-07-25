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
                    RoastLevel = table.Column<string>(type: "TEXT", nullable: true),
                    SourceName = table.Column<string>(type: "TEXT", nullable: true)
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
                    { new Guid("3f5fbbec-a13c-4c64-8c45-daf9819a67ba"), "789 Derby Ln, Louisville, KY", "derbydaycoffee@example.com", "Derby Day Coffee" },
                    { new Guid("4ccace88-d885-4e44-8c87-f9a153f4c77f"), "321 Bardstown Rd, Louisville, KY", "bardstownbrews@example.com", "Bardstown Brews" },
                    { new Guid("6c5a4129-046f-4c6e-b082-e078339b4286"), "987 Cherokee Rd, Louisville, KY", "cherokeeparkperks@example.com", "Cherokee Park Perks" },
                    { new Guid("82d543d9-f70b-41f3-94b2-cf780ee229ca"), "135 Churchill Dr, Louisville, KY", "churchillgrinds@example.com", "Churchill Grinds" },
                    { new Guid("8d01c2a1-2e77-4ba0-a0bb-7f5826f4c781"), "456 River Rd, Louisville, KY", "rivercityroasts@example.com", "River City Roasts" },
                    { new Guid("ccd5de04-bdd7-42e9-a9f1-638c3efae7cd"), "246 East Market St, Louisville, KY", "nulujava@example.com", "NuLu Java" },
                    { new Guid("ec8ce1b2-dba8-46f4-bd57-68ce7cf727d5"), "654 Southern Pkwy, Louisville, KY", "southerncomfortcafe@example.com", "Southern Comfort Cafe" },
                    { new Guid("f44f57d2-9167-4810-ac47-aedbaf8d5cbc"), "123 Main St, Louisville, KY", "bluegrassbeans@example.com", "Bluegrass Beans" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Amount", "ClientId", "DateOrdered", "Name", "Price", "RoastLevel", "SourceName" },
                values: new object[,]
                {
                    { new Guid("3af4d7f6-bf1f-4da6-9d6f-097bc2a5c2b8"), 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluegrass Beans", 120.00m, "Light", "Fazenda Santa Ines, Minas Gerais, Brazil" },
                    { new Guid("464b02e0-7082-40c6-9931-8078f3e35302"), 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluegrass Beans", 170.00m, "Light", "Hunkute Cooperative, Sidamo, Ethiopia" },
                    { new Guid("5b48ce81-4e93-4888-a618-3360a906873f"), 12, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bardstown Brews", 160.00m, "Medium", "Finca El Injerto, Huehuetenango, Guatemala" },
                    { new Guid("898c64cc-0df1-42be-88a8-cb3b1e24adca"), 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Derby Day Coffee", 140.00m, "Dark", "La Soledad, Acatenango, Guatemala" },
                    { new Guid("91996708-d833-42a3-804a-90f9004332a2"), 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Churchill Grinds", 120.00m, "Dark", "Hacienda El Roble, Santander, Colombia" },
                    { new Guid("afd0d4ad-c96d-4090-aee0-55aeeef90736"), 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "River City Roasts", 150.00m, "Dark", "Guji Highland Farm, Guji, Ethiopia" },
                    { new Guid("baab65be-064b-46f5-b0ac-54e3b165edb7"), 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cherokee Park Perks", 150.00m, "Medium", "Finca Deborah, Volcan, Panama" },
                    { new Guid("c5124582-3b53-42e2-a199-db275c7fecfd"), 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Southern Comfort Cafe", 180.00m, "Dark", "Hacienda La Esmeralda, Boquete, Panama" },
                    { new Guid("d6f03f16-048a-4ca8-952e-02fa81f9c2d8"), 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NuLu Java", 160.00m, "Medium", "Finca Los Nogales, Tolima, Colombia" },
                    { new Guid("fe7600d6-745d-4ff0-be34-47ebf6090b02"), 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "River City Roasts", 110.00m, "Medium", "Carmo Estate, Sul de Minas, Brazil" }
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "ID", "Cost", "Farm", "Location" },
                values: new object[,]
                {
                    { new Guid("1d3f4bfc-e3d1-414c-b202-100930c0dfc2"), 2.75m, "Carmo Estate, Sul de Minas", "Brazil" },
                    { new Guid("25eed7af-23dd-42ce-ad63-38c075a22bd6"), 3.78m, "Hunkute Cooperative, Sidamo", "Ethiopia" },
                    { new Guid("546b7556-57f0-46a6-b8a0-3dfcab4f8cdb"), 4.29m, "Guji Highland Farm, Guji", "Ethiopia" },
                    { new Guid("5d90ef3d-d504-4dcd-8c1f-d5699036c071"), 2.40m, "Fazenda Santa Ines, Minas Gerais", "Brazil" },
                    { new Guid("60575eb9-a088-4ffc-9010-3c02a4ce87dd"), 3.00m, "Finca Deborah, Volcan", "Panama" },
                    { new Guid("66a5636b-f794-4652-98c6-2cfdf32dbdfb"), 3.00m, "Hacienda El Roble, Santander", "Colombia" },
                    { new Guid("6b221e39-41a7-45a6-908f-60dd71e77e50"), 4.00m, "Hacienda La Esmeralda, Boquete", "Panama" },
                    { new Guid("7fc1027b-fe84-4b82-89fa-ec9023a60748"), 4.67m, "La Soledad, Acatenango", "Guatemala" },
                    { new Guid("8914d73b-c01d-45a5-9558-df60626a6436"), 2.91m, "Finca Los Nogales, Tolima", "Colombia" },
                    { new Guid("cac137ca-ea56-4f87-b33f-7fc72d9ab680"), 2.67m, "Finca El Injerto, Huehuetenango", "Guatemala" }
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
