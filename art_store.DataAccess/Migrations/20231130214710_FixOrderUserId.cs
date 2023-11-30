using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "dbo",
                table: "Orders",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "dbo",
                table: "Orders",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
