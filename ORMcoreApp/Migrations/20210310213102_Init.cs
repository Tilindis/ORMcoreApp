using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORMcoreApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "automobiliai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarMake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passengers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_automobiliai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pareigunai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pareigunai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzduotys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzduotys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ginklai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GunName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GunModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GunID = table.Column<int>(type: "int", nullable: false),
                    pareigunasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ginklai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ginklai_pareigunai_pareigunasId",
                        column: x => x.pareigunasId,
                        principalTable: "pareigunai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skirtinguDienuAutomobiliai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pareigunasId = table.Column<int>(type: "int", nullable: true),
                    automobilisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skirtinguDienuAutomobiliai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_skirtinguDienuAutomobiliai_automobiliai_automobilisId",
                        column: x => x.automobilisId,
                        principalTable: "automobiliai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_skirtinguDienuAutomobiliai_pareigunai_pareigunasId",
                        column: x => x.pareigunasId,
                        principalTable: "pareigunai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uzduociuListai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    uzduotisId = table.Column<int>(type: "int", nullable: true),
                    pareigunasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzduociuListai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uzduociuListai_pareigunai_pareigunasId",
                        column: x => x.pareigunasId,
                        principalTable: "pareigunai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uzduociuListai_Uzduotys_uzduotisId",
                        column: x => x.uzduotisId,
                        principalTable: "Uzduotys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ginklai_pareigunasId",
                table: "ginklai",
                column: "pareigunasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_skirtinguDienuAutomobiliai_automobilisId",
                table: "skirtinguDienuAutomobiliai",
                column: "automobilisId");

            migrationBuilder.CreateIndex(
                name: "IX_skirtinguDienuAutomobiliai_pareigunasId",
                table: "skirtinguDienuAutomobiliai",
                column: "pareigunasId");

            migrationBuilder.CreateIndex(
                name: "IX_uzduociuListai_pareigunasId",
                table: "uzduociuListai",
                column: "pareigunasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uzduociuListai_uzduotisId",
                table: "uzduociuListai",
                column: "uzduotisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ginklai");

            migrationBuilder.DropTable(
                name: "skirtinguDienuAutomobiliai");

            migrationBuilder.DropTable(
                name: "uzduociuListai");

            migrationBuilder.DropTable(
                name: "automobiliai");

            migrationBuilder.DropTable(
                name: "pareigunai");

            migrationBuilder.DropTable(
                name: "Uzduotys");
        }
    }
}
