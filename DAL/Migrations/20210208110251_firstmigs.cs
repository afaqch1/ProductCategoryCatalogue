using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class firstmigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "category_id1",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "category_id1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id1",
                table: "Products",
                column: "category_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id1",
                table: "Products",
                column: "category_id1",
                principalTable: "Categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
