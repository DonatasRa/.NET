using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 1, null, null, "Todo1" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 2, null, null, "Todo2" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 3, null, null, "Todo3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
