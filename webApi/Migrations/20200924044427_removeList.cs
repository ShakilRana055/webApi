using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class removeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_InformationId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_InformationId",
                table: "Address",
                column: "InformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_InformationId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_InformationId",
                table: "Address",
                column: "InformationId");
        }
    }
}
