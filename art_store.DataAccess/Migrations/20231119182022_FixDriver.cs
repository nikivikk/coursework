using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Drivers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
