using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialSystem.DataAccess.Migrations
{
    public partial class AddedOwnerUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "FS",
                table: "InvoiceNote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "FS",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "FS",
                table: "InvoiceNote");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "FS",
                table: "Invoice");
        }
    }
}
