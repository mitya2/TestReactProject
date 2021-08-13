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
                    { 1, "", 1, new DateTime(2021, 8, 13, 15, 20, 1, 248, DateTimeKind.Local).AddTicks(8970), 1 },
                    { 2, "Безналичная оплата", 2, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(6986), 2 },
                    { 3, "Оплата наличкой", 3, new DateTime(2021, 5, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(7058), 3 },
                    { 4, null, 1, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(7063), 4 },
                    { 5, null, 2, new DateTime(2021, 5, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(7065), 5 },
                    { 7, null, 1, new DateTime(2020, 8, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(7069), 5 },
                    { 6, "Оплата наличкой", 3, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(7067), 6 }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderDetails",
                columns: new[] { "SalesOrderDetailId", "ModifyDate", "OrderQuantity", "ProductId", "SalesOrderId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(8825), 5, 1, 1, 100m },
                    { 18, new DateTime(2018, 4, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9178), 10, 4, 5, 400m },
                    { 17, new DateTime(2019, 2, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9176), 10, 3, 5, 300m },
                    { 16, new DateTime(2019, 12, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9175), 10, 2, 5, 200m },
                    { 15, new DateTime(2020, 10, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9173), 10, 1, 5, 100m },
                    { 14, new DateTime(2020, 10, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9170), 1, 1, 4, 100m },
                    { 13, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9168), 60, 6, 3, 100m },
                    { 12, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9166), 50, 5, 3, 100m },
                    { 11, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9165), 40, 2, 3, 100m },
                    { 10, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9163), 30, 1, 3, 100m },
                    { 9, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9161), 20, 3, 2, 100m },
                    { 8, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9159), 10, 2, 2, 100m },
                    { 7, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9157), 5, 1, 2, 100m },
                    { 6, new DateTime(2021, 5, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9112), 50, 6, 1, 600m },
                    { 5, new DateTime(2021, 5, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9111), 2, 5, 1, 500m },
                    { 4, new DateTime(2021, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9108), 1, 4, 1, 400m },
                    { 3, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9106), 15, 3, 1, 300m },
                    { 2, new DateTime(2021, 7, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9101), 10, 2, 1, 200m },
                    { 19, new DateTime(2017, 6, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9180), 10, 5, 5, 500m },
                    { 20, new DateTime(2016, 8, 13, 15, 20, 1, 249, DateTimeKind.Local).AddTicks(9182), 10, 6, 5, 600m }
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
