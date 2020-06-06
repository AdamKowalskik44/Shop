using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class addCartEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartEntries",
                columns: table => new
                {
                    CartEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEntries", x => x.CartEntryId);
                    table.ForeignKey(
                        name: "FK_CartEntries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartEntries_ProductId",
                table: "CartEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartEntries_UserId",
                table: "CartEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartEntries");
        }
    }
}
