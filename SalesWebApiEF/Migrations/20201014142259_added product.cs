using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebApiEF.Migrations
{
    public partial class addedproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Orderline");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orderline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_ProductId",
                table: "Orderline",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderline_Product_ProductId",
                table: "Orderline",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderline_Product_ProductId",
                table: "Orderline");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Orderline_ProductId",
                table: "Orderline");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orderline");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orderline",
                type: "decimal(11,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Orderline",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
