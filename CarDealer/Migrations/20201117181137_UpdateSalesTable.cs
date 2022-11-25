using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Migrations
{
    public partial class UpdateSalesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerID",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalespersonID",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleID",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BuyerID",
                table: "Sale",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_SalespersonID",
                table: "Sale",
                column: "SalespersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_VehicleID",
                table: "Sale",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Buyer_BuyerID",
                table: "Sale",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Salesperson_SalespersonID",
                table: "Sale",
                column: "SalespersonID",
                principalTable: "Salesperson",
                principalColumn: "SalespersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Vehicle_VehicleID",
                table: "Sale",
                column: "VehicleID",
                principalTable: "Vehicle",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Buyer_BuyerID",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Salesperson_SalespersonID",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Vehicle_VehicleID",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_BuyerID",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_SalespersonID",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_VehicleID",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SalespersonID",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "VehicleID",
                table: "Sale");
        }
    }
}
