using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopListApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

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
                    table.ForeignKey(
                        name: "FK_ShopItems_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemTags",
                columns: table => new
                {
                    ShopItemId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemTags", x => new { x.TagId, x.ShopItemId });
                    table.ForeignKey(
                        name: "FK_ShopItemTags_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItemTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Skudurynas" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Krautuve" });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 28, 5, 27, 5, 229, DateTimeKind.Utc).AddTicks(147), "Kepure", 1 },
                    { 2, new DateTime(2021, 12, 28, 5, 27, 5, 229, DateTimeKind.Utc).AddTicks(510), "Batai", 1 },
                    { 3, new DateTime(2021, 12, 28, 5, 27, 5, 229, DateTimeKind.Utc).AddTicks(513), "Bulves", 2 },
                    { 4, new DateTime(2021, 12, 28, 5, 27, 5, 229, DateTimeKind.Utc).AddTicks(515), "Morkos", 2 },
                    { 5, new DateTime(2021, 12, 28, 5, 27, 5, 229, DateTimeKind.Utc).AddTicks(517), "Svogunai", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemTags_ShopItemId",
                table: "ShopItemTags",
                column: "ShopItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemTags");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
