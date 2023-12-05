using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConnectDatabases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Drivers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Arts",
                newName: "Arts",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "dbo",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Drivers",
                schema: "dbo",
                newName: "Drivers");

            migrationBuilder.RenameTable(
                name: "Arts",
                schema: "dbo",
                newName: "Arts");
        }
    }
}
