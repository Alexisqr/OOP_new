using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComentGlob",
                table: "ComentGlob");

            migrationBuilder.RenameTable(
                name: "ComentGlob",
                newName: "ComentGlobs");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ComentGlobs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComentGlobs",
                table: "ComentGlobs",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameKind = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KindOfAnimals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfAnimals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Volonters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volonters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComentGoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDGood = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentGoods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComentGoods_Goods_IDGood",
                        column: x => x.IDGood,
                        principalTable: "Goods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentGoods_Volonters_IDVolonter",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentKindAnimalss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDKindAnimals = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentKindAnimalss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComentKindAnimalss_KindOfAnimals_IDKindAnimals",
                        column: x => x.IDKindAnimals,
                        principalTable: "KindOfAnimals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentKindAnimalss_Volonters_IDVolonter",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentGlobs_IDVolonter",
                table: "ComentGlobs",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "IX_ComentGoods_IDGood",
                table: "ComentGoods",
                column: "IDGood");

            migrationBuilder.CreateIndex(
                name: "IX_ComentGoods_IDVolonter",
                table: "ComentGoods",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "IX_ComentKindAnimalss_IDKindAnimals",
                table: "ComentKindAnimalss",
                column: "IDKindAnimals");

            migrationBuilder.CreateIndex(
                name: "IX_ComentKindAnimalss_IDVolonter",
                table: "ComentKindAnimalss",
                column: "IDVolonter");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentGlobs_Volonters_IDVolonter",
                table: "ComentGlobs",
                column: "IDVolonter",
                principalTable: "Volonters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentGlobs_Volonters_IDVolonter",
                table: "ComentGlobs");

            migrationBuilder.DropTable(
                name: "ComentGoods");

            migrationBuilder.DropTable(
                name: "ComentKindAnimalss");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "KindOfAnimals");

            migrationBuilder.DropTable(
                name: "Volonters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComentGlobs",
                table: "ComentGlobs");

            migrationBuilder.DropIndex(
                name: "IX_ComentGlobs_IDVolonter",
                table: "ComentGlobs");

            migrationBuilder.RenameTable(
                name: "ComentGlobs",
                newName: "ComentGlob");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ComentGlob",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComentGlob",
                table: "ComentGlob",
                column: "ID");
        }
    }
}
