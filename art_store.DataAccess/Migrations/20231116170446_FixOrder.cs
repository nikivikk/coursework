using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Driver",
                table: "Arts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Driver",
                table: "Arts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
