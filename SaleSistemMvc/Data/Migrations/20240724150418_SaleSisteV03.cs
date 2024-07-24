using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleSistemMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class SaleSisteV03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_UserAccount_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SaleId",
                table: "Product",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BuyerId",
                table: "Sale",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sale_SaleId",
                table: "Product",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sale_SaleId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Product_SaleId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Product");
        }
    }
}
