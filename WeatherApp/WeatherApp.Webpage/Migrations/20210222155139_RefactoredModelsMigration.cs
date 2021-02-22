using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.WebSite.Migrations
{
    public partial class RefactoredModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Observations",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Observations",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Observations",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Observations",
                newName: "ID");
        }
    }
}
