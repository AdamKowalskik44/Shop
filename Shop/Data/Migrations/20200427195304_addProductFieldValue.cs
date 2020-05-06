using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class addProductFieldValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Categories_CategoryId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CategoryId",
                table: "CustomFields");

            migrationBuilder.AddColumn<int>(
                name: "_categoryId",
                table: "CustomFields",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductFieldValues",
                columns: table => new
                {
                    ProductFieldValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomFieldId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Value = table.Column<bool>(nullable: true),
                    ProductFieldValueDDI_Value = table.Column<string>(nullable: true),
                    ProductFieldValueFloat_Value = table.Column<float>(nullable: true),
                    ProductFieldValueInt_Value = table.Column<int>(nullable: true),
                    ProductFieldValueString_Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFieldValues", x => x.ProductFieldValueId);
                    table.ForeignKey(
                        name: "FK_ProductFieldValues_CustomFields_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomFields",
                        principalColumn: "CustomFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFieldValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields__categoryId",
                table: "CustomFields",
                column: "_categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFieldValues_CustomFieldId",
                table: "ProductFieldValues",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFieldValues_ProductId",
                table: "ProductFieldValues",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Categories__categoryId",
                table: "CustomFields",
                column: "_categoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Categories__categoryId",
                table: "CustomFields");

            migrationBuilder.DropTable(
                name: "ProductFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields__categoryId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "_categoryId",
                table: "CustomFields");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CategoryId",
                table: "CustomFields",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Categories_CategoryId",
                table: "CustomFields",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
