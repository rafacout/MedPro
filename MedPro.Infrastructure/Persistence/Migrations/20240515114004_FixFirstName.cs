using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPro.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixFirstName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstFirstName",
                table: "Patients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FirstFirstName",
                table: "Doctors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Patients",
                newName: "FirstFirstName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Doctors",
                newName: "FirstFirstName");
        }
    }
}
