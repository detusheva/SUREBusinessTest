using Microsoft.EntityFrameworkCore.Migrations;

namespace SUREBusiness.Migrations
{
    public partial class addingMobileNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Note",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Note");
        }
    }
}
