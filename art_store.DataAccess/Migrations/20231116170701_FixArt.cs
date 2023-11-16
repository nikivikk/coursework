using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixArt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Orders_OrderId",
                table: "Arts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Arts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Orders_OrderId",
                table: "Arts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_Orders_OrderId",
                table: "Arts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Arts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_Orders_OrderId",
                table: "Arts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
