using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations
{
    /// <inheritdoc />
    public partial class newMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_Value",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Value",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Value",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name_Value",
                table: "Patients");
        }
    }
}
