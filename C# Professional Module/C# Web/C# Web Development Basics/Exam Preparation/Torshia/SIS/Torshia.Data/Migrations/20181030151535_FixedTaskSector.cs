using Microsoft.EntityFrameworkCore.Migrations;

namespace Torshia.Data.Migrations
{
    public partial class FixedTaskSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TasksSectors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TasksSectors",
                nullable: false,
                defaultValue: 0);
        }
    }
}
