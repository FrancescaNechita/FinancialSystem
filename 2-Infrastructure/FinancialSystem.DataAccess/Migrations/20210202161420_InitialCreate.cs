using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialSystem.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FS");

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "FS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNote",
                schema: "FS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceNote_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "FS",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNote_InvoiceId",
                schema: "FS",
                table: "InvoiceNote",
                column: "InvoiceId");

            migrationBuilder.Sql("ALTER TABLE [FS].[Invoice] ADD CONSTRAINT CK_MinAmountValue CHECK(Amount > 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceNote",
                schema: "FS");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "FS");
        }
    }
}
