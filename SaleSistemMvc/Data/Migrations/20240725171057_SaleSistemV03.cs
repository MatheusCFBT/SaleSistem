using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleSistemMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class SaleSistemV03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sale_SaleId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SaleId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "ProductBuyedId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductBuyedId",
                table: "Sale",
                column: "ProductBuyedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductBuyedId",
                table: "Sale",
                column: "ProductBuyedId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductBuyedId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ProductBuyedId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProductBuyedId",
                table: "Sale");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Sale",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SaleId",
                table: "Product",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sale_SaleId",
                table: "Product",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id");
        }
    }
}
