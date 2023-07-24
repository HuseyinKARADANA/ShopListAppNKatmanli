using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class OrderRealtedClassesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItemUsers_Items_ItemId",
                table: "FavoriteItemUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Items_ItemId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderDetails",
                newName: "ItemDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ItemDetailId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "InvoiceDetails",
                newName: "ItemDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_ItemId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_ItemDetailId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "FavoriteItemUsers",
                newName: "ItemDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItemUsers_ItemId",
                table: "FavoriteItemUsers",
                newName: "IX_FavoriteItemUsers_ItemDetailId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SmartPhones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                table: "ItemDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ItemDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ItemDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_UserId",
                table: "ItemDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItemUsers_ItemDetails_ItemDetailId",
                table: "FavoriteItemUsers",
                column: "ItemDetailId",
                principalTable: "ItemDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_ItemDetails_ItemDetailId",
                table: "InvoiceDetails",
                column: "ItemDetailId",
                principalTable: "ItemDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetails_Users_UserId",
                table: "ItemDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailId",
                table: "OrderDetails",
                column: "ItemDetailId",
                principalTable: "ItemDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItemUsers_ItemDetails_ItemDetailId",
                table: "FavoriteItemUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_ItemDetails_ItemDetailId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetails_Users_UserId",
                table: "ItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_ItemDetails_UserId",
                table: "ItemDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SmartPhones");

            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                table: "ItemDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemDetails");

            migrationBuilder.RenameColumn(
                name: "ItemDetailId",
                table: "OrderDetails",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ItemDetailId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ItemId");

            migrationBuilder.RenameColumn(
                name: "ItemDetailId",
                table: "InvoiceDetails",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_ItemDetailId",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_ItemId");

            migrationBuilder.RenameColumn(
                name: "ItemDetailId",
                table: "FavoriteItemUsers",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItemUsers_ItemDetailId",
                table: "FavoriteItemUsers",
                newName: "IX_FavoriteItemUsers_ItemId");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FavoriteCount = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItemUsers_Items_ItemId",
                table: "FavoriteItemUsers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Items_ItemId",
                table: "InvoiceDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemId",
                table: "OrderDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
