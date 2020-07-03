using Microsoft.EntityFrameworkCore.Migrations;

namespace SUREBusiness.Data.Migrations
{
    public partial class AddingManagerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Note");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Note",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Note");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Note",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
