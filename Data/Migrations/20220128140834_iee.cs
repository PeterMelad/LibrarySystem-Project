using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class iee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBook_books_BookID",
                table: "BorrowBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBook_Borrowers_BorrowerID",
                table: "BorrowBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowBook",
                table: "BorrowBook");

            migrationBuilder.RenameTable(
                name: "BorrowBook",
                newName: "BorrowBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBook_BorrowerID",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_BorrowerID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBook_BookID",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowBooks",
                table: "BorrowBooks",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_books_BookID",
                table: "BorrowBooks",
                column: "BookID",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Borrowers_BorrowerID",
                table: "BorrowBooks",
                column: "BorrowerID",
                principalTable: "Borrowers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_books_BookID",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Borrowers_BorrowerID",
                table: "BorrowBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowBooks",
                table: "BorrowBooks");

            migrationBuilder.RenameTable(
                name: "BorrowBooks",
                newName: "BorrowBook");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_BorrowerID",
                table: "BorrowBook",
                newName: "IX_BorrowBook_BorrowerID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_BookID",
                table: "BorrowBook",
                newName: "IX_BorrowBook_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowBook",
                table: "BorrowBook",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBook_books_BookID",
                table: "BorrowBook",
                column: "BookID",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBook_Borrowers_BorrowerID",
                table: "BorrowBook",
                column: "BorrowerID",
                principalTable: "Borrowers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
