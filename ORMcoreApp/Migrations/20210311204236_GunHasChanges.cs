using Microsoft.EntityFrameworkCore.Migrations;

namespace ORMcoreApp.Migrations
{
    public partial class GunHasChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ginklai_pareigunai_pareigunasId",
                table: "ginklai");

            migrationBuilder.DropIndex(
                name: "IX_ginklai_pareigunasId",
                table: "ginklai");

            migrationBuilder.DropColumn(
                name: "pareigunasId",
                table: "ginklai");

            migrationBuilder.AddColumn<int>(
                name: "ginklasId",
                table: "pareigunai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pareigunai_ginklasId",
                table: "pareigunai",
                column: "ginklasId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pareigunai_ginklai_ginklasId",
                table: "pareigunai",
                column: "ginklasId",
                principalTable: "ginklai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pareigunai_ginklai_ginklasId",
                table: "pareigunai");

            migrationBuilder.DropIndex(
                name: "IX_pareigunai_ginklasId",
                table: "pareigunai");

            migrationBuilder.DropColumn(
                name: "ginklasId",
                table: "pareigunai");

            migrationBuilder.AddColumn<int>(
                name: "pareigunasId",
                table: "ginklai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ginklai_pareigunasId",
                table: "ginklai",
                column: "pareigunasId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ginklai_pareigunai_pareigunasId",
                table: "ginklai",
                column: "pareigunasId",
                principalTable: "pareigunai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
