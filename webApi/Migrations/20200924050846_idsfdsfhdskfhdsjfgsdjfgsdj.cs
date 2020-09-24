using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class idsfdsfhdskfhdsjfgsdjfgsdj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_InformationId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_InformationId",
                table: "Address",
                column: "InformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
