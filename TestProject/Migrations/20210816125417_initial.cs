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
                    SalesOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetails", x => x.SalesOrderDetailId);
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
                    { 1, "Иванов Иван Иванович" },
                    { 2, "Петров Петр Петрович" },
                    { 3, "Сидоров Сидор Сидорович" }
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
                    { 1, "", 1, new DateTime(2021, 8, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(1050), 1 },
                    { 2, "Безналичная оплата", 2, new DateTime(2021, 7, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9753), 2 },
                    { 3, "Оплата наличкой", 3, new DateTime(2021, 5, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9833), 3 },
                    { 4, null, 1, new DateTime(2021, 6, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9839), 4 },
                    { 5, null, 2, new DateTime(2021, 5, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9841), 5 },
                    { 7, null, 1, new DateTime(2020, 8, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9844), 5 },
                    { 6, "Оплата наличкой", 3, new DateTime(2021, 6, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9843), 6 }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderDetails",
                columns: new[] { "SalesOrderDetailId", "ModifyDate", "OrderQuantity", "ProductId", "SalesOrderId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1624), 5, 1, 1, 100m },
                    { 18, new DateTime(2018, 4, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1922), 10, 4, 5, 400m },
                    { 17, new DateTime(2019, 2, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1920), 10, 3, 5, 300m },
                    { 16, new DateTime(2019, 12, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1918), 10, 2, 5, 200m },
                    { 15, new DateTime(2020, 10, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1916), 10, 1, 5, 100m },
                    { 14, new DateTime(2020, 10, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1914), 1, 1, 4, 100m },
                    { 13, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1912), 60, 6, 3, 100m },
                    { 12, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1910), 50, 5, 3, 100m },
                    { 11, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1909), 40, 2, 3, 100m },
                    { 10, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1907), 30, 1, 3, 100m },
                    { 9, new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1905), 20, 3, 2, 100m },
                    { 8, new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1903), 10, 2, 2, 100m },
                    { 7, new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1901), 5, 1, 2, 100m },
                    { 6, new DateTime(2021, 5, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1899), 50, 6, 1, 600m },
                    { 5, new DateTime(2021, 5, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1896), 2, 5, 1, 500m },
                    { 4, new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1895), 1, 4, 1, 400m },
                    { 3, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1893), 15, 3, 1, 300m },
                    { 2, new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1887), 10, 2, 1, 200m },
                    { 19, new DateTime(2017, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1924), 10, 5, 5, 500m },
                    { 20, new DateTime(2016, 8, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1925), 10, 6, 5, 600m }
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
