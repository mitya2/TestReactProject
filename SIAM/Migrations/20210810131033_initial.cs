using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SalesStatuses",
                columns: table => new
                {
                    SalesStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesStatuses", x => x.SalesStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesStatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrders_SalesStatuses_SalesStatusId",
                        column: x => x.SalesStatusId,
                        principalTable: "SalesStatuses",
                        principalColumn: "SalesStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, "Иванов" },
                    { 2, "Петров" },
                    { 3, "Сидоров" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Comment", "Name", "Price" },
                values: new object[,]
                {
                    { 14, null, "Манго", 1000m },
                    { 13, null, "Нектарин", 200m },
                    { 12, null, "Абрикос", 250m },
                    { 11, null, "Персик", 240m },
                    { 10, null, "Виноград", 399m },
                    { 8, null, "Зеленый лук", 50m },
                    { 9, null, "Свекла", 200m },
                    { 6, null, "Лимон", 200m },
                    { 5, null, "Лесной орех", 1200m },
                    { 4, "Мытая", "Морковь", 40m },
                    { 3, null, "Банан", 55m },
                    { 2, "Сорт Голден", "Яблоко", 100m },
                    { 1, null, "Картофель", 50m },
                    { 7, null, "Имбирь", 2000m }
                });

            migrationBuilder.InsertData(
                table: "SalesStatuses",
                columns: new[] { "SalesStatusId", "Name" },
                values: new object[,]
                {
                    { 5, "Готов к отгрузке" },
                    { 1, "Создан" },
                    { 2, "Обрабатывается" },
                    { 3, "Принят" },
                    { 4, "Оплачен" },
                    { 6, "Отгружен" }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "SalesOrderId", "Comment", "CustomerId", "OrderDate", "SalesStatusId" },
                values: new object[,]
                {
                    { 1, "", 1, new DateTime(2021, 8, 10, 16, 10, 32, 885, DateTimeKind.Local).AddTicks(4276), 1 },
                    { 2, "Безналичная оплата", 2, new DateTime(2021, 7, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2402), 2 },
                    { 3, "Оплата наличкой", 3, new DateTime(2021, 5, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2473), 3 },
                    { 4, null, 1, new DateTime(2021, 6, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2478), 4 },
                    { 5, null, 2, new DateTime(2021, 5, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2480), 5 },
                    { 7, null, 1, new DateTime(2020, 8, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2483), 5 },
                    { 6, "Оплата наличкой", 3, new DateTime(2021, 6, 10, 16, 10, 32, 886, DateTimeKind.Local).AddTicks(2482), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_ProductId",
                table: "SalesOrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_SalesOrderId",
                table: "SalesOrderDetails",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_SalesStatusId",
                table: "SalesOrders",
                column: "SalesStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesStatuses");
        }
    }
}
