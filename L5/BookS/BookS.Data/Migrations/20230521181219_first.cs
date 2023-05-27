using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookS.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    EditionType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Copies = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    AgeRestriction = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Nayden", "Vitanov" },
                    { 2, "Deyan", "Tanev" },
                    { 3, "Desislav", "Petkov" },
                    { 4, "Dyakon", "Hristov" },
                    { 5, "Milen", "Todorov" },
                    { 6, "Aleksander", "Kishishev" },
                    { 7, "Ilian", "Stoev" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Drama" },
                    { 3, "Action" },
                    { 4, "Adventure" },
                    { 5, "Romance" },
                    { 6, "Mystery" },
                    { 7, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AgeRestriction", "AuthorId", "Copies", "Description", "EditionType", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, 1, 27274, "lALA", 0, 15.31m, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Absalom" },
                    { 2, 0, 2, 16159, "lALA", 0, 35.56m, new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "After Many a Summer Dies the Swan" },
                    { 3, 0, 3, 29025, "lALA", 1, 23.71m, new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ah" },
                    { 4, 2, 4, 9998, "lALA", 2, 5.26m, new DateTime(1993, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilderness" },
                    { 5, 2, 5, 18832, "lALA", 2, 5.69m, new DateTime(2014, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alien CornÂ (play)" },
                    { 6, 2, 6, 28741, "lALA", 0, 34.56m, new DateTime(2003, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Alien CornÂ (short story)" },
                    { 7, 1, 7, 20471, "lALA", 1, 7.18m, new DateTime(1991, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "All Passion Spent" }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 2, 6 },
                    { 3, 5 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 2 },
                    { 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
