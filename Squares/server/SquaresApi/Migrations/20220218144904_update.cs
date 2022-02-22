using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquaresApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_PointLists_PointListId",
                table: "Points");

            migrationBuilder.AlterColumn<int>(
                name: "PointListId",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_PointLists_PointListId",
                table: "Points",
                column: "PointListId",
                principalTable: "PointLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_PointLists_PointListId",
                table: "Points");

            migrationBuilder.AlterColumn<int>(
                name: "PointListId",
                table: "Points",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_PointLists_PointListId",
                table: "Points",
                column: "PointListId",
                principalTable: "PointLists",
                principalColumn: "Id");
        }
    }
}
