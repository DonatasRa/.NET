using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopListApp.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 16, 16, 47, 49, 708, DateTimeKind.Utc).AddTicks(9915), "Kepure", 1 },
                    { 2, new DateTime(2021, 12, 16, 16, 47, 49, 709, DateTimeKind.Utc).AddTicks(255), "Batai", 1 },
                    { 3, new DateTime(2021, 12, 16, 16, 47, 49, 709, DateTimeKind.Utc).AddTicks(257), "Bulves", 2 },
                    { 4, new DateTime(2021, 12, 16, 16, 47, 49, 709, DateTimeKind.Utc).AddTicks(260), "Morkos", 2 },
                    { 5, new DateTime(2021, 12, 16, 16, 47, 49, 709, DateTimeKind.Utc).AddTicks(262), "Svogunai", 2 }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Skudurynas" },
                    { 2, "Krautuve" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
