using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class innn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCount",
                table: "books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateOfRecieve = table.Column<DateTime>(nullable: false),
                    DateOfBorrow = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowBook",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    BorrowerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowBook", x => x.id);
                    table.ForeignKey(
                        name: "FK_BorrowBook_books_BookID",
                        column: x => x.BookID,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowBook_Borrowers_BorrowerID",
                        column: x => x.BorrowerID,
                        principalTable: "Borrowers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBook_BookID",
                table: "BorrowBook",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBook_BorrowerID",
                table: "BorrowBook",
                column: "BorrowerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowBook");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "books");
        }
    }
}
