using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppTest.Migrations
{
    /// <inheritdoc />
    public partial class dateonlyorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPosition_Orders_OrderId",
                table: "OrdersPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersPosition_Products_ProductId",
                table: "OrdersPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersPosition",
                table: "OrdersPosition");

            migrationBuilder.RenameTable(
                name: "OrdersPosition",
                newName: "OrderPositions");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPosition_ProductId",
                table: "OrderPositions",
                newName: "IX_OrderPositions_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersPosition_OrderId",
                table: "OrderPositions",
                newName: "IX_OrderPositions_OrderId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RegDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPositions",
                table: "OrderPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPositions_Orders_OrderId",
                table: "OrderPositions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPositions_Products_ProductId",
                table: "OrderPositions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPositions_Orders_OrderId",
                table: "OrderPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPositions_Products_ProductId",
                table: "OrderPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPositions",
                table: "OrderPositions");

            migrationBuilder.RenameTable(
                name: "OrderPositions",
                newName: "OrdersPosition");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPositions_ProductId",
                table: "OrdersPosition",
                newName: "IX_OrdersPosition_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPositions_OrderId",
                table: "OrdersPosition",
                newName: "IX_OrdersPosition_OrderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersPosition",
                table: "OrdersPosition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPosition_Orders_OrderId",
                table: "OrdersPosition",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersPosition_Products_ProductId",
                table: "OrdersPosition",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
