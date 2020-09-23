using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class removingNullableInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Information_InformationId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "InformationId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Information_InformationId",
                table: "Address",
                column: "InformationId",
                principalTable: "Information",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Information_InformationId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "InformationId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Information_InformationId",
                table: "Address",
                column: "InformationId",
                principalTable: "Information",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
